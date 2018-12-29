-- Project .............: R-DaaS
-- Author ..............: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
-- Copyright ...........: Copyright (C) 2018 Greg Beam, KI7MT
-- License .............: GPL-3

-- File ................: R-DaaS_Enum-Views.sql
-- Description .........: Views for Enumeration Tables
-- Database Type .......: PostgreSQL v10 or later
-- Version .............: 1.0.0
-- ADIF Specification ..: 3.0.9


\echo ''
\echo '-----------------------------'
\echo 'Creating User Views'
\echo '-----------------------------'


--******************************************************************************
-- Table: antenna_path
--******************************************************************************

-- View: rdaas.vw_antenna_path
CREATE OR REPLACE VIEW rdaas.antenna_path_view AS
    SELECT 
        antenna_path.abbreviation AS "Abbreviation",
        antenna_path.meaning AS "Meaning"
    FROM rdaas.antenna_path
    ORDER BY rdaas.antenna_path.abbreviation;

--******************************************************************************
-- Table: arrl_section
--******************************************************************************

-- View: rdaas.vw_arrl_section
CREATE OR REPLACE VIEW rdaas.arrl_section_view AS
    SELECT 
        arrl_section.abbreviation AS "Abbreviation",
        arrl_section.name AS "Section Name",
        dxcc_entity.code AS "DXCC Code",
        dxcc_entity.name AS "DXCC Name",
        arrl_section.from_date AS "From Date",
        arrl_section.deleted_date AS "Deleted On"
    FROM rdaas.arrl_section
        JOIN rdaas.dxcc_entity ON 
            rdaas.dxcc_entity.id = rdaas.arrl_section.id
    ORDER BY arrl_section.name;


--******************************************************************************
-- Table: rdaas.vw_award
--******************************************************************************

-- View: rdaas.vw_award
CREATE OR REPLACE VIEW rdaas.band_view AS
    SELECT
        band.name AS "Band",
        band.lower_freq AS "Lower Freq (MHZ)",
        band.upper_freq AS "Upper Freq (MHZ)"
    FROM rdaas.band
    ORDER BY band.lower_freq;


--******************************************************************************
-- Table: rdaas.award_view
--******************************************************************************

-- View: rdaas.award_view
CREATE OR REPLACE VIEW rdaas.award_view AS
    SELECT
        award.name AS "Award Name",
        award.import_only AS "Import Only"
    FROM rdaas.award
    ORDER BY award.name;


--******************************************************************************
-- Table: rdaas.vw_contest
--******************************************************************************

-- View: rdaas.vw_contest
CREATE OR REPLACE VIEW rdaas.contest_view AS
    SELECT
        contest.name AS "Contest Name",
        contest.description AS "Description",
        contest.import_only AS "Import Only",
        weblink.url AS "Weblink URL"
    FROM rdaas.contest
        LEFT JOIN rdaas.weblink ON
            rdaas.weblink.id = rdaas.contest.weblink_id
    ORDER BY contest.name;


--******************************************************************************
-- Table: rdaas.vw_continent
--******************************************************************************

-- View: rdaas.vw_continent
CREATE OR REPLACE VIEW rdaas.continent_view AS
    SELECT
        continent.abbreviation AS "Abbreviation",
        continent.name AS "Continent"
    FROM rdaas.continent
    ORDER BY continent.abbreviation;


--******************************************************************************
-- Table: rdaas.vw_county_name
--******************************************************************************

-- View: rdaas.vw_county_name
CREATE OR REPLACE VIEW rdaas.county_name_view AS
    SELECT
        county_name.name AS "County Name"
    FROM rdaas.county_name
    ORDER BY county_name.name;


--******************************************************************************
-- Table: rdaas.vw_credit_award
--******************************************************************************

-- View: rdaas.vw_credit_award
CREATE OR REPLACE VIEW rdaas.credit_award_view AS
    SELECT
        credit_award.name AS "Award Name"
    FROM rdaas.credit_award
    ORDER BY credit_award.name;

--******************************************************************************
-- Table: rdaas.vw_credit_facet
--******************************************************************************

-- View: rdaas.vw_credit_facet
CREATE OR REPLACE VIEW rdaas.credit_facet_view AS
    SELECT
        credit_facet.name AS "Facet"
    FROM rdaas.credit_facet
    ORDER BY credit_facet.name;

--******************************************************************************
-- Table: rdaas.vw_credit_sponsor
--******************************************************************************

-- View: rdaas.vw_credit_sponsor
CREATE OR REPLACE VIEW rdaas.credit_sponsor_view AS
    SELECT
        credit_sponsor.name AS "Sponsor"
    FROM rdaas.credit_sponsor
    ORDER BY credit_sponsor.name;


--******************************************************************************
-- Table: rdaas.vw_credit
--******************************************************************************

-- View: rdaas.vw_credit
CREATE OR REPLACE VIEW rdaas.credit_view AS
    SELECT
        credit_for AS "Credit For",
        credit_sponsor.name AS "Sponsor",
        credit_award.name AS "Award",
        credit_facet.name AS "Facet"
    FROM rdaas.credit
        LEFT JOIN rdaas.credit_sponsor ON
            rdaas.credit_sponsor.id = rdaas.credit.sponsor_id
        LEFT JOIN rdaas.credit_award ON
            rdaas.credit_award.id = rdaas.credit.award_id
        LEFT JOIN rdaas.credit_facet ON
            rdaas.credit_facet.id = rdaas.credit.facet_id
    ORDER BY credit_for;


--******************************************************************************
-- Table: rdaas.vw_dxcc_entity
--******************************************************************************

-- View: rdaas.vw_dxcc_entity
CREATE OR REPLACE VIEW rdaas.dxcc_entity_view AS
    SELECT
        dxcc_entity.code AS "DXCC Code",
        dxcc_entity.name AS "DXCC Name",
        dxcc_entity.is_deleted as "Deleted"
    FROM rdaas.dxcc_entity
    ORDER BY dxcc_entity.code;


--******************************************************************************
-- Table: rdaas.vw_state
--******************************************************************************

-- View: rdaas.vw_state
CREATE OR REPLACE VIEW rdaas.state_view AS
    SELECT
        state.abbreviation AS "Abbreviation",
        state.name AS "Name"
    FROM rdaas.state
    ORDER BY state.name;


--******************************************************************************
-- Table: rdaas.vw_state_county
--******************************************************************************

-- View: rdaas.vw_state_county
CREATE OR REPLACE VIEW rdaas.state_county_view AS
    SELECT
        state.abbreviation AS "Abbreviation",
        state.name AS "State",
        county_name.name AS "County"
    FROM rdaas.state_county
        JOIN rdaas.state ON
            rdaas.state.id = rdaas.state_county.state_id
        JOIN rdaas.county_name ON
            rdaas.county_name.id = rdaas.state_county.county_name_id
    ORDER by state.name


\echo ''
\echo 'Finished Creating Enum Views'
\echo 'Version ........: 1.0.0'
\echo 'ADIF Spec ......: 3.0.9'
\echo 'Report Bugs to..: https://github.com/KI7MT/dotnet-core-examples/issues'
\echo ''



-- END R-DaaS-Enum-Views.sql
