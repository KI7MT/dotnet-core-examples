/*
  Look for foreign key constraints that are missing indexes on the
  referencing table.

  Orders results by the size of the referencing table, largest first,
  on the assumption that, all else being equal, they are the most likely
  to benefit from the addition of indexes.

  This is only meant as a starting point, and isn't perfect.
  It's possible, for example, that it will report a missing index
  when in fact one is available. e.g., it won't realize that an index on
  (f1, f2) could be used with a fk on (f1). However, it will recognize
  that an index on (f1, f2) can be used with a fk on (f2, f1).

  Credit: http://mlawire.blogspot.com/2009/08/postgresql-indexes-on-foreign-keys.html

  Usage: psql -U postgres -f pg-find-missing-fk-indexes.sql

*/

-- FUNCTION --------------------------------------------------------------------

CREATE OR REPLACE FUNCTION pg_temp.sortarray(int2[]) returns int2[] as '
  SELECT ARRAY(
      SELECT $1[i]
        FROM generate_series(array_lower($1, 1), array_upper($1, 1)) i
    ORDER BY 1
  )
' language sql;

-- RUN THIS QUERY FOR RESULTS --------------------------------------------------
\echo ''
\echo '* Generating Recommending Foregion Key Index List.'
\echo '* Does not list Indexes already created.'
\echo ''
SELECT conrelid::regclass
        ,conname
        ,reltuples::bigint
  FROM pg_constraint
        JOIN pg_class ON (conrelid = pg_class.oid)
  WHERE contype = 'f'
        AND NOT EXISTS (
          SELECT 1
            FROM pg_index
          WHERE indrelid = conrelid
                AND pg_temp.sortarray(conkey) = pg_temp.sortarray(indkey)
        )
ORDER BY reltuples DESC
;
