/*
  Look for foreign key constraints that are missing indexes on the
  referencing table, and recommend indexes.

  Credit: https://stackoverflow.com/questions/2970050/postgresql-how-to-index-all-foreign-keys

  Usage: psql -q postgres -f index-recomend1.sql

*/

-- RUN THIS as a QUERY
\echo ''
\echo '* Generating Recommending Foregion Key Index List'
\echo '* Lists all requirments, even if the Index Exists.'
\echo ''
select pg_index.indexrelid::regclass, 'create index ' || relname || '_' ||
         array_to_string(column_name_list, '_') || '_idx on ' || confrelid ||
         ' (' || array_to_string(column_name_list, ',') || ')'
from (select distinct
       confrelid,
       array_agg(attname) column_name_list,
       array_agg(attnum) as column_list
     from pg_attribute
          join (select confrelid::regclass,
                 conname,
                 unnest(confkey) as column_index
                from (select distinct
                        confrelid, conname, confkey
                      from pg_constraint
                        join pg_class on pg_class.oid = pg_constraint.confrelid
                        join pg_namespace on pg_namespace.oid = pg_class.relnamespace
                      where nspname !~ '^pg_' and nspname <> 'information_schema'
                      ) fkey
               ) fkey
               on fkey.confrelid = pg_attribute.attrelid
                  and fkey.column_index = pg_attribute.attnum
     group by confrelid, conname
     ) candidate_index
join pg_class on pg_class.oid = candidate_index.confrelid
left join pg_index on pg_index.indrelid = confrelid
                      and indkey::text = array_to_string(column_list, ' ')