/* 

    Project .............: R-DaaS
    Author ..............: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
    Copyright ...........: Copyright (C) 2018 Greg Beam, KI7MT
    License .............: GPL-3

    File ................: lotw-import.sql
    Description .........: Script to import LoTW Active user csv file
    Database Type .......: PostgreSQL v10 or later
    Version .............: 1.0.0
    ADIF Specification ..: 3.0.9

    Tool Requirments:

    * PostgreSQL v10 or above
    * Access to Curl or Wget (Native Linux, WSL, Powershell, WinSSL, other)

    Installation and Usage Instrucitons
    
    1. Download lotw-user-activity.csv file and place it in the 
       same directory as this script resides.

        wget -c https://lotw.arrl.org/lotw-user-activity.csv

        or with Curl, just copy and paste the command

        curl -o lotw-user-activity.csv -z lotw-user-activity.csv https://lotw.arrl.org/lotw-user-activity.csv

    2. In the Terminal, run the following command:

       psql -v ON_ERROR_STOP=1 -U postgres -f lotw-import.sql

    3. After installation, run the following query to test the installaiton:

       psql -U postgres -c "select * from rdaas.lotw_test_view"

*/

-- *****************************************************************************
--  BEGIN TABLE GENERATION and IMPORT
-- *****************************************************************************

\echo ''
\echo '---------------------------'
\echo 'Creating LoTW Table'
\echo '---------------------------'

-- Drop table if exists
DROP TABLE IF EXISTS rdaas.lotw_activity CASCADE;

-- LoTW Active Users
CREATE TABLE rdaas.lotw_activity
(
    callsign TEXT NOT NULL,
    last_update DATE NOT NULL,
    last_time TIME NOT NULL,
    CONSTRAINT lotw_activity_callsign_pkey PRIMARY KEY (callsign)
);

\echo ''
\echo '---------------------------'
\echo 'Importing LoTW Data'
\echo '---------------------------'
\COPY rdaas.lotw_activity FROM 'lotw-user-activity.csv' DELIMITER ',' QUOTE '"' HEADER CSV;

\echo ''
\echo '---------------------------'
\echo 'Adding Test Query'
\echo '---------------------------'

-- Create Test View: rdaas.lotw_test_view
CREATE OR REPLACE VIEW rdaas.lotw_test_view AS
    SELECT
        lotw_activity.callsign AS "Callsign",
        lotw_activity.last_update AS "Last Update",
        lotw_activity.last_time AS "Time"
    FROM rdaas.lotw_activity
        WHERE last_update > '2018-12-1' AND last_update < '2018-12-31'
        ORDER BY last_update DESC,
            last_time DESC
        LIMIT 10;

\echo ''
\echo '=> Finished Installing LoTW Activity Data'
\echo '=> Running Test Query: rdaas.lotw_test_view'
\echo ''
select * from rdaas.lotw_test_view;
\echo 'Finished !!'

-- END: lotw-import.sql