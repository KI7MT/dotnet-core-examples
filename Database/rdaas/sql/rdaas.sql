/* 

    Project .............: R-DaaS
    Author ..............: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
    Copyright ...........: Copyright (C) 2018 Greg Beam, KI7MT
    License .............: GPL-3

    File ................: rdaas.sql
    Description .........: Enumeration Tables for R-DaaS Project
    Database Type .......: PostgreSQL v10 or later
    Version .............: 1.0.0
    ADIF Specification ..: 3.0.9
    ADIF Refrence .......: http://www.adif.org/309/ADIF_309.htm#Enumerations
    Bug Reports .........: https://github.com/KI7MT/dotnet-core-examples/issues'

    Comments
    
        This schema implements section III.B of the Amateur Data Interchange
        Format (ADIF) in a 3NF normalized fashion (or close to it). The intent
        is to keep the data-set static and in sync with specification revisions.
        Users should refrain from modifying the data directly unless you are
        willing to accept the deviation from the spec.

    Tool Requirments:

        * PostgreSQL v10 or above
        * git for cloning the repository
        * RDaaS uses the default database (postgres) and password (postgres)
          If you want to use a different Role / DB, adjust the commands as needed.

    Installation
    
        * Clone the repository

            git clone https://github.com/KI7MT/dotnet-core-examples.git
        
        * Change directories and run the sql script

            cd dotnet-dore-examples\Database\rdaas\sql

            psql -v ON_ERROR_STOP=1 -U postgres -f rdaas.sql

    Development Activity and Coding

        Suffix Annotations
        _uq     = Unique Constraint
        _pkey   = Primary Key
        _fkey   = Foreign Key

        TODO: rdaas.oblast will need an FK for PSA or SAS before its functional.
        TODO: rdaas.pas and rdaas.sas CSV files for data entry
        TODO: Add rdaas.sas FK's after rdaas.pas has been populated.

*/

-- *****************************************************************************
--  BEGIN SCHEMA CREATION
-- *****************************************************************************

\echo ''
\echo '---------------------------'
\echo 'Creating R-DaaS Schema'
\echo '---------------------------'

-- Drop, and re-create schema
DROP SCHEMA IF EXISTS rdaas CASCADE;

\echo ''
\echo '==========================='
\echo 'Creating Schema rdaas'
\echo '==========================='

-- Create New Schema
CREATE SCHEMA rdaas;

--R-DaaS Informaiton Table
CREATE TABLE rdaas.database_info
(
    id INT PRIMARY KEY,
    author VARCHAR (20),
    db_version VARCHAR(10),
    adif_spec VARCHAR(10),
    last_update DATE
);

INSERT INTO rdaas.database_info (id, author, db_version, adif_spec, last_update)
VALUES(1, 'Greg Beam', '1.0.0', '3.0.9', '2018-12-28');

-- *****************************************************************************
--  BEGIN TABLE CREATION
-- *****************************************************************************

\echo ''
\echo '==========================='
\echo 'Creating Tables'
\echo '==========================='

-- Antenna Path
CREATE TABLE rdaas.antenna_path
(
    id SERIAL PRIMARY KEY,
    abbreviation VARCHAR(1) NOT NULL,
    meaning VARCHAR(15) NOT NULL,
    CONSTRAINT antenna_path_uq UNIQUE (abbreviation, meaning)
);

-- Award
CREATE TABLE rdaas.award
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(15),
    import_only BOOLEAN NOT NULL DEFAULT '1',
    CONSTRAINT award_name_uq UNIQUE (name)
);

-- ARRL Section
-- FK => dxcc_entity_fkey REFERENCEES rdaas.dxcc_entity (id)
CREATE TABLE rdaas.arrl_section
(
    id SERIAL PRIMARY KEY,
    abbreviation VARCHAR(4) NOT NULL,
    name VARCHAR(70) NOT NULL,
    dxcc_entity_id INT NOT NULL,
    from_date date,
    deleted_date date
);

-- Band
CREATE TABLE rdaas.band
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(6) NOT NULL,
    lower_freq NUMERIC NOT NULL,
    upper_freq NUMERIC NOT NULL,
    CONSTRAINT band_name_uq UNIQUE (name)
);

-- Contest
CREATE TABLE rdaas.contest
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(60),
    description VARCHAR(120),
    import_only BOOLEAN NOT NULL DEFAULT '0',
    weblink_id INT,
    CONSTRAINT contest_name_uq UNIQUE (name)
);

-- Continent
CREATE TABLE rdaas.continent
(
    id SERIAL PRIMARY KEY,
    abbreviation VARCHAR(2),
    name VARCHAR(14),
    CONSTRAINT continent_name_uq UNIQUE (abbreviation, name)
);

-- Credit Sponsor
CREATE TABLE rdaas.credit_sponsor
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(20),
    CONSTRAINT credit_sponsor_name_uq UNIQUE (name)
);

-- Credit Award
CREATE TABLE rdaas.credit_award
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(60),
    CONSTRAINT credit_award_name_uq UNIQUE (name)
);

-- Credit Facet
CREATE TABLE rdaas.credit_facet
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(20),
    CONSTRAINT credit_facet_name_uq UNIQUE (name)
);

-- Credit
-- FK => credit_sponsor_fkey REFERENCE rdaas.credit_sponsor (id)
-- FK => credit_award_fkey REFERENCE rdaas.credit_award (id)
-- FK => credit_facetPfkey REFERENCE rdaas.credit_facet (id)
CREATE TABLE rdaas.credit
(
    id SERIAL PRIMARY KEY,
    credit_for VARCHAR(24) NOT NULL,
    sponsor_id INT NOT NULL,
    award_id INT NOT NULL,
    facet_id INT NOT NULL,
CONSTRAINT credit_for_uq UNIQUE (credit_for)
);

-- DXCC Entities
-- id is a natureal PK as it matches dscc_entity_id
CREATE TABLE rdaas.dxcc_entity
(
    id INT PRIMARY KEY,
    code VARCHAR(4) NOT NULL,
    name VARCHAR(90) NOT NULL,
    is_deleted BOOLEAN DEFAULT '0',
    CONSTRAINT dxcc_entity_name_uq UNIQUE (code, name)
);

-- State
CREATE TABLE rdaas.state
(
    id SERIAL PRIMARY KEY,
    abbreviation VARCHAR(2) NOT NULL,
    name VARCHAR(20) NOT NULL,
    CONSTRAINT state_uq UNIQUE (abbreviation, name)
);

-- County
CREATE TABLE rdaas.county_name
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(60) NOT NULL,
    CONSTRAINT county_name_uq UNIQUE (name)
);

-- State County Many-To-Many
-- FK => state_county_state_fkey REFERENCE rdaas.state (id)
-- FK => state_county_county_name_fkey REFERENCE rdaas.county_name (id)
CREATE TABLE rdaas.state_county
(
    id SERIAL PRIMARY KEY,
    state_id INT NOT NULL,
    county_name_id INT NOT NULL
);

-- Mode
-- FK => mode_mode_description REFERENCEES rdaas.mode_description (id)
CREATE TABLE rdaas.mode
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(20) NOT NULL,
    mode_description_id INT,
    import_only BOOLEAN NOT NULL DEFAULT '0',
    CONSTRAINT mode_name_uq UNIQUE (name)
);

-- Submode One-To-Many
-- FK => submode_mode REFERENCES rdaas.mode (id)
-- FK => subode_mode_description_fkey REFERENCE rdaas.mode_description (id)
CREATE TABLE rdaas.submode
(
    id SERIAL PRIMARY KEY,
    mode_id INT NOT NULL,
    name VARCHAR(20) NOT NULL,
    mode_description_id INT,
    CONSTRAINT submode_name_uq UNIQUE (name)
);

-- Mode Description
CREATE TABLE rdaas.mode_description
(
    id SERIAL PRIMARY KEY,
    description VARCHAR(120) NOT NULL
);

-- CQ Zone
-- PK id is the same as the cqzone_number = No SERIAL, use INT
CREATE TABLE rdaas.cq_zone
(
    id INT PRIMARY KEY,
    short_description VARCHAR(60) NOT NULL,
    long_description VARCHAR NOT NULL,
    weblink_id INT
);

-- ITU Zone
-- PK id is the same ans the itu_zone_number = No SERIAL, use INT
CREATE TABLE rdaas.itu_zone
(
    id INT PRIMARY KEY,
    number INT NOT NULL,
    short_description VARCHAR(120),
    long_description VARCHAR (255),
    weblink_id INT,
    CONSTRAINT itu_zone_number_uq UNIQUE (number)
);

-- Oblast
-- TO-DO: rdaas.oblast will need an FK for PSA or SAS before its functional.
CREATE TABLE rdaas.oblast
(
    id SERIAL PRIMARY KEY,
    code VARCHAR(10) NOT NULL,
    name VARCHAR(120) NOT NULL,
    is_deleted BOOLEAN NOT NULL DEFAULT '0',
    comment VARCHAR(120) NOT NULL,
    CONSTRAINT oblast_code_uq UNIQUE (code)
);

-- Propogation
CREATE TABLE rdaas.propogation_mode
(
    id SERIAL PRIMARY KEY,
    enumeration VARCHAR(20) NOT NULL,
    description VARCHAR(120) NOT NULL,
    CONSTRAINT propogation_mode_abbreviation_uq UNIQUE (enumeration)
);

-- Primary Administrative Subdivision
-- FK pas_dxcc_entity_fkey REFERENCE rdaas.dxcc_entity (id)
CREATE TABLE rdaas.pas
(
    id SERIAL PRIMARY KEY,
    dxcc_entity_id INT NOT NULL,
    code VARCHAR(10) NOT NULL,
    subdivision VARCHAR(80) NOT NULL,
    CONSTRAINT pas_code_uq UNIQUE (code)
);

-- Secondary Administrative Subdivision
-- FK_sas_pas_id REFERENCE rdaas.pas (id) 
CREATE TABLE rdaas.sas
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(80) NOT NULL,
    pas_id INT NOT NULL,
    CONSTRAINT sas_name_uq UNIQUE (name)
);

-- QSL Medium
CREATE TABLE rdaas.qsl_medium
(
    id SERIAL PRIMARY KEY,
    medium VARCHAR(10) NOT NULL,
    description VARCHAR(120) NOT NULL,
    CONSTRAINT qsl_medium_uq UNIQUE (medium)
);

-- QSL Recieved
CREATE TABLE rdaas.qsl_rcvd
(
    id SERIAL PRIMARY KEY,
    status VARCHAR(1) NOT NULL,
    meaning VARCHAR(20) NOT NULL,
    import_only BOOLEAN NOT NULL DEFAULT '0',
    description VARCHAR(255),
    CONSTRAINT qsl_rcvd_status_uq UNIQUE (status)
);

-- QSL Sent
CREATE TABLE rdaas.qsl_sent
(
    id SERIAL PRIMARY KEY,
    status VARCHAR(1) NOT NULL,
    meaning VARCHAR(20) NOT NULL,
    description VARCHAR(255),
    CONSTRAINT qsl_sent_status_uq UNIQUE (status)
);

-- QSL Via
CREATE TABLE rdaas.qsl_via
(
    id SERIAL PRIMARY KEY,
    via VARCHAR(1) NOT NULL,
    description VARCHAR(20) NOT NULL,
    import_only BOOLEAN NOT NULL DEFAULT '0',
    CONSTRAINT qsl_via_uq UNIQUE (via)
);

-- QSO Complete
CREATE TABLE rdaas.qso_complete
(
    id SERIAL PRIMARY KEY,
    abbreviation VARCHAR(5) NOT NULL,
    meaning VARCHAR(20) NOT NULL,
    CONSTRAINT qso_complete_abbreviation_uq UNIQUE (abbreviation)
);

-- QSO Upload Status
CREATE TABLE rdaas.qso_upload_status
(
    id SERIAL PRIMARY KEY,
    abbreviaiton VARCHAR(1) NOT NULL,
    description VARCHAR(120) NOT NULL,
    CONSTRAINT qso_upload_status_abbreviation_uq UNIQUE (abbreviaiton)
);

-- Region
CREATE TABLE rdaas.region
(
    id SERIAL PRIMARY KEY,
    code VARCHAR(4),
    dxcc_entity_id INT,
    region VARCHAR(120),
    prefix VARCHAR(10),
    CONSTRAINT region_code_uq UNIQUE (code)
);

-- Region Applicability 
CREATE TABLE rdaas.region_applicability
(
    id SERIAL PRIMARY KEY,
    region_id INT NOT NULL,
    weblink_id INT NOT NULL
);

-- Web Link Section
CREATE TABLE rdaas.weblink
(
    id SERIAL PRIMARY KEY,
    display_text VARCHAR(120) NOT NULL,
    url VARCHAR(255) NOT NULL,
    CONSTRAINT weblink_display_text_uq UNIQUE (display_text)
);

-- Sponsored Award
CREATE TABLE rdaas.sponsored_award
(
    id SERIAL PRIMARY KEY,
    sponsor VARCHAR(20) NOT NULL,
    weblink_id INT NOT NULL,
    CONSTRAINT qso_sponsored_award_sponsor_uq UNIQUE (sponsor)
);

-- *****************************************************************************
--  LOTW, EQSL, JTALERTS DATA MODELS
-- *****************************************************************************

-- NOTES: These models are part of the main installation to facilitate
--        generating the R-DaaS API and WebMVC. They are duplicates
--        from the sql scripts residing in .\lotw .\eqsl and .\jtalert.
--        CSV data import is through their individual sql scripts.

-- LoTW Active Users Model
CREATE TABLE rdaas.lotw_activity
(
    callsign TEXT NOT NULL,
    last_update DATE NOT NULL,
    last_time TIME NOT NULL,
    CONSTRAINT lotw_activity_callsign_pkey PRIMARY KEY (callsign)
);

-- eSQL Data Model
CREATE TABLE rdaas.eqsl_ag_list
(
    id SERIAL PRIMARY KEY,
    callsign TEXT NOT NULL
);

-- JTAlerts Data Model
CREATE TABLE rdaas.jtalert_data
(
    call VARCHAR(20),
    state VARCHAR(4),
    lotw BOOLEAN,
    eqsl BOOLEAN,
    lotw_date DATE,
    CONSTRAINT jtalert_data_pkey PRIMARY KEY (call)
);

-- *****************************************************************************
--  ADD CSV DATA
-- *****************************************************************************

-- NOTE(s): 
--  1. Delimiter for dxc_entity is "|" due to comma's in 'name' column
--  2. All other CSV files use ',' delimiters with double-quote escapes

\echo ''
\echo '---------------------------'
\echo 'Importing CSV Files'
\echo '---------------------------'
\COPY rdaas.antenna_path FROM 'antenna_path.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.arrl_section FROM 'arrl_section.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.award FROM 'award.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.band FROM 'band.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.contest FROM 'contest.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.continent FROM 'continent.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.county_name FROM 'county_name.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.credit FROM 'credit.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.credit_award FROM 'credit_award.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.credit_facet FROM 'credit_facet.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.credit_sponsor FROM 'credit_sponsor.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.dxcc_entity FROM 'dxcc_entity.csv' DELIMITER '|' QUOTE '"' HEADER CSV;
\COPY rdaas.state FROM 'state.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.state_county FROM 'state_county.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.mode FROM 'mode.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.submode FROM 'submode.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.propogation_mode FROM 'propogation_mode.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.qsl_medium FROM 'qsl_medium.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.qsl_rcvd FROM 'qsl_rcvd.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.qsl_sent FROM 'qsl_sent.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.qsl_via FROM 'qsl_via.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.qso_complete FROM 'qsl_complete.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.qso_upload_status FROM 'qso_upload_status.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.region FROM 'region.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.region_applicability FROM 'region_applicability.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.weblink FROM 'weblink.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.sponsored_award FROM 'sponsored_award.csv' DELIMITER ',' QUOTE '"' HEADER CSV;
\COPY rdaas.cq_zone FROM 'cq_zone.csv' DELIMITER ',' QUOTE '"' HEADER CSV;

-- *****************************************************************************
--  ADD FOREIGN KEYS
-- *****************************************************************************

\echo ''
\echo '---------------------------'
\echo 'Adding Foreign Keys'
\echo '---------------------------'

ALTER TABLE rdaas.arrl_section ADD CONSTRAINT arrl_section_dxcc_entity_fkey
    FOREIGN KEY (dxcc_entity_id) REFERENCES rdaas.dxcc_entity (id);

ALTER TABLE rdaas.contest ADD CONSTRAINT contest_weblink_fkey
    FOREIGN KEY (weblink_id) REFERENCES rdaas.weblink (id);

ALTER TABLE rdaas.credit ADD CONSTRAINT credit_credit_sponsor_fkey
    FOREIGN KEY (sponsor_id) REFERENCES rdaas.credit_sponsor (id);

ALTER TABLE rdaas.credit ADD CONSTRAINT credit_credit_award_fkey
    FOREIGN KEY (award_id) REFERENCES rdaas.credit_award (id);

ALTER TABLE rdaas.credit ADD CONSTRAINT credit_credit_facet_fkey
    FOREIGN KEY (facet_id) REFERENCES rdaas.credit_facet (id);

ALTER TABLE rdaas.state_county ADD CONSTRAINT state_county_state_fkey
    FOREIGN KEY (state_id) REFERENCES rdaas.state (id);

ALTER TABLE rdaas.state_county ADD CONSTRAINT state_county_county_name_fkey
    FOREIGN KEY (county_name_id) REFERENCES rdaas.county_name (id);

ALTER TABLE rdaas.pas ADD CONSTRAINT pas_dxcc_entity_fkey
    FOREIGN KEY (dxcc_entity_id) REFERENCES rdaas.dxcc_entity (id);

ALTER TABLE rdaas.sas ADD CONSTRAINT sas_pas_fkey
    FOREIGN KEY (pas_id) REFERENCES rdaas.pas (id);

ALTER TABLE rdaas.region ADD CONSTRAINT region_dxcc_entity_fkey
    FOREIGN KEY (dxcc_entity_id) REFERENCES rdaas.dxcc_entity (id);

ALTER TABLE rdaas.mode ADD CONSTRAINT mode_mode_description_fkey
    FOREIGN KEY (mode_description_id) REFERENCES rdaas.mode_description (id);

ALTER TABLE rdaas.submode ADD CONSTRAINT submode_mode_fkey
    FOREIGN KEY (mode_id) REFERENCES rdaas.mode (id);

ALTER TABLE rdaas.submode ADD CONSTRAINT submode_mode_description_fkey
    FOREIGN KEY (mode_description_id) REFERENCES rdaas.mode_description (id);

-- *****************************************************************************
--  GENERATE INDEXES based on utilitiies\index-reccomend2.sql
-- *****************************************************************************

\echo ''
\echo '-----------------------------'
\echo 'Creating Foreign Key Indexes'
\echo '-----------------------------'

CREATE INDEX contest_weblink_id_idx on rdaas.contest (weblink_id);
create index state_county_county_name_id_idx on rdaas.state_county (county_name_id);
create index submode_mode_description_id_idx on rdaas.submode (mode_description_id);
create index pas_dxcc_entity_id_idx on rdaas.pas (dxcc_entity_id);
create index credit_facet_id_idx on rdaas.credit (facet_id);
create index submode_mode_id_idx on rdaas.submode (mode_id);
create index sas_pas_id_idx on rdaas.sas (pas_id);
create index arrl_section_dxcc_entity_id_idx on rdaas.arrl_section (dxcc_entity_id);
create index credit_award_id_idx on rdaas.credit (award_id);
create index credit_sponsor_id_idx on rdaas.credit (sponsor_id);
create index state_county_state_id_idx on rdaas.state_county (state_id);
create index region_dxcc_entity_id_idx on rdaas.region (dxcc_entity_id);
create index mode_mode_description_id_idx on rdaas.mode (mode_description_id);

-- *****************************************************************************
--  GENERATE rdaas.database_info_view
-- *****************************************************************************

-- Create Test View: rdaas.database_info_view
CREATE OR REPLACE VIEW rdaas.database_info_view AS
    SELECT
        database_info.author AS "Author",
        database_info.db_version AS "DB Version",
        database_info.adif_spec AS "ADIF Spec",
        database_info.last_update AS "Revision Date"
    FROM rdaas.database_info;

-- *****************************************************************************
--  PRIN FOOTER
-- *****************************************************************************

\echo ''
\echo 'Finished Creating R-DaaS Enumeration Schema'
\echo ''
\echo 'Database Information'
\echo ''
select * from rdaas.database_info_view;
\echo 'Project Data'
\echo ''
\echo 'Github URL ......: https://github.com/KI7MT/dotnet-core-examples'
\echo 'ADIF Refrence ...: http://www.adif.org/309/ADIF_309.htm#Enumerations'
\echo 'Report Bugs to ..: https://github.com/KI7MT/dotnet-core-examples/issues'
\echo ''

-- END rdaas.sql