# RDaaS Project

>NOTE: This page is under heavy revision. Expect things to change at rapid
>pace.

## Page Index

- [Overview](#overview)
- [Usability](#usability)
- [System Requirements](#system-requirements)
- [Development and Environment](#development-and-environment)
- [Current Testing](#current-testing)
  1. [Checkout Repository](#checkout-repository)
  1. [Database Initialization](#database-initialization)
  1. [Add Table Views](#add-table-views)
  1. [Test Utility Scripts](#test-utility-scripts)
  1. [List All Views](#list-all-views)
  1. [View List Matrix](#view-list-matrix)
  1. [ADIF Table Views](#adif-table-views)
  1. [Database Specific Views](#database-specific-views)
  1. [Performance Checking](#performance-checking)
  1. [Update LoTW Data](#update-lotw-data)
- [Next Phase](#next-phase)
- [Bug Reports](#bug-reports)

## Overview

The Radio Data as a Service (RDaaS) project aims to provide radio amateurs with
a single, scalable set of end-points for data access. As the project grows, so
shall this section of the dotnet-core-examples repository.

The conceptual components can be broken down into three basic areas during
development, and the order of work:

* Data Store (Postgresql, MongoDB, Redis, other Data Stores)
* Application API (JSON/JSONB) RESt Endpoints
* Web Based Interface for administration, or Web MVC.

The current focus is on the Data Store and solidifying the base models
to start working the API and looking at overall performance.

## Usability

At the time of this writing, all example applications are being tested on:

* Window-10 build 17134 x86_64
* [Windows Subsystem Linux (WSL)](https://docs.microsoft.com/en-us/windows/wsl/about)
* Linux Native [Ubuntu 18.04](http://releases.ubuntu.com/18.04/)
* If the [.Net Core SDK](#system-requirments) can run on a particular system, so should RDaaS.

## System Requirements

* Supported Operating Systems: `Windows`, `Linux`, `MacOS`
* [Net Core SDK v2.2+](https://dotnet.microsoft.com/download)
* [VS Code Editor](https://code.visualstudio.com/) is optional but preferred
* Dual Core CPU Minimum
* At Least 1GB RAM
* 1 to 2 GB of Free disk space (if running all apps, less if not)
* [PostgreSQL Database](https://github.com/KI7MT/jtsdk-dotnet-core/wiki/Install-PostgreSQL)

## Development and Environment

The following applications are in various state(s) of development, anywhere from
Database Design to final API/MVC integration. A given project may reside in the
repository, but should not be considered functional. As they move from
development to testing, I will move them to Stable or Testing.

## Current Testing

|Application  |Database |DB Setup|Status|Description
| :---        |:---|:---|:---    |:---
|[RDaaS-Data](https://github.com/KI7MT/dotnet-core-examples/tree/master/Database)|PostgreSQL|[See Docs](https://github.com/KI7MT/jtsdk-dotnet-core/wiki/Install-PostgreSQL)|Testing|Database backend for the RDaaS project
|[RDaaS-API](https://github.com/KI7MT/dotnet-core-examples/tree/master/Database)|PostgreSQL|TBD|Devel|Swagger RESt-API for Radio Related Data
|[RDaaS-MVC](https://github.com/KI7MT/dotnet-core-examples/tree/master/Database)|PostgreSQL|TBD|Devel|Razor WebMVC for Admin Access to RDaaS

Currently, `Database Initialization` is the focus. In order to run the SQL scripts,
you must have [PostgreSQL v10+](https://github.com/KI7MT/jtsdk-dotnet-core/wiki/Install-PostgreSQL)
installed. This can be through [JTSDK-Tools](https://github.com/KI7MT/jtsdk-dotnet-core/wiki),
or a native installation for the system you are running. The Default
installation is preferred:

```shell

# These are the defaults if you do not change them during installation

Host.......: localhost
Port.......: 5432
Username...: postgres
Password...: postgres
Database...: postgres
```

>NOTE: If you change any of these items, you must adjust the instructions to match.

## Database Initialization

In order to use `psql`, you must be able to access it directly from the command-line. This can be a native console or `JTSK-Tools` environment. Until this works properly, you
should not continue. For all of actions in this document,
I will be using `JTSDK-Tools Env`.

### Psql Version Check

```shell
# Open a Terminal, Windows CMD, Powershell, Linux Terminal and type:

psql --version
````

| ![Psql Version](docs/images/psql-version.PNG?raw=true) |
|:--:|
| *psql version check* |

### Checkout Repository

It is your choice where you checkout the source code. To keep things consistent,
I prefer the src directory in `JTSDK-Tools Env`.

Checkout the repository, and `cd /d` to the `rdaas` folder.

```shell
# Checkout dotnet-core-examples

cd /d (C|D):\JTSDK-Tools\src

git clone https://github.com/KI7MT/dotnet-core-examples.git

cd /d dotnet-core-examples\Database\rdaas\sql
```

### Initialize The Database

In the terminal, review the available SQL Scripts, then run the main `rdaas.sql` script.

```shell
# List the *.sql scripts we'll be using

# Windows:
dir /b *.sql

# Linux
ls *.sql
```

| ![Initial Script List](docs/images/script-list1.PNG?raw=true) |
|:--:|
| *Initial Script List* |

Run the `rdaas.sql` script using `psql` command (copy and paste should work too):

>NOTE: this script drops the Schema each times it's runs. If you need or want to
>re-initialize the DB, just run the script again. However, doing so will mean you
must re-add the utilities and views.

```shell
psql -v ON_ERROR_STOP=1 -U postgres -f rdaas.sql
```

If the script finishes without error, you should see the following output:

| ![Successful Install](docs/images/successful-install.PNG?raw=true) |
|:--:|
| *Successful Install* |

### Add Table Views

This step is similar to initialization. The difference being, we are adding
query views for testing.

```shell
psql -v ON_ERROR_STOP=1 -U postgres -f rdaas-views.sql
```

| ![Query View Install](docs/images/query-views.PNG?raw=true) |
|:--:|
| *Query View Install* |

### Add Utility Views

The next step we'll install some useful utility views.

```shell
# Change directories to utilities and install the views

cd utilities

psql -v ON_ERROR_STOP=1 -U postgres -f rdaas-utilities.sql
```

| ![Utility View Install](docs/images/utility-views.PNG?raw=true) |
|:--:|
| *Utility View Install* |

### List All Views

Now that we have the utilities installed, you can print a list of available views.

```shell
# Call the the rdaas.view_list

psql -U postgres -c "SELECT * FROM rdaas.view_list"
```

| ![View List](docs/images/view-list.PNG?raw=true) |
|:--:|
| *View List* |

As you can see in the image above, there are a number of views I've
created just for testing. By the time the DB is production ready, many more
views will be created along with store procedures and other triggers.
For now, see the `view_list` matrix below for details of each view.

### View List Matrix

The following are the supplied views and their command to render them. The syntax
is the same for all elements in the view_list, with the exception of the name of the view itself. Many combinations exist for views, however, the commands below simply look through each table with a select all (*) command.

### ADIF Table Views

These are jsut a small sample of what's to be added, but, it's a start for
testing basic performance.

|Name           |Command
| :---          |:---
|Antenna Path   | psql -U postgres -c "SELECT * FROM rdaas.antenna_path_view"
|ARRL Section   | psql -U postgres -c "SELECT * FROM rdaas.arrl_section_view"
|Award          | psql -U postgres -c "SELECT * FROM rdaas.award_view"
|Band           | psql -U postgres -c "SELECT * FROM rdaas.band_view"
|Contest        | psql -U postgres -c "SELECT * FROM rdaas.contest_view"
|Continent      | psql -U postgres -c "SELECT * FROM rdaas.continent_view"
|County Name    | psql -U postgres -c "SELECT * FROM rdaas.county_name_view"
|Credit         | psql -U postgres -c "SELECT * FROM rdaas.credit_view"
|Credit Award   | psql -U postgres -c "SELECT * FROM rdaas.credit_award_view"
|Credit Facet   | psql -U postgres -c "SELECT * FROM rdaas.credit_facet_view"
|Credit Sponsor |psql -U postgres -c "SELECT * FROM rdaas.credit_sponsor_view"
|DXCC Entity    | psql -U postgres -c "SELECT * FROM rdaas.dxcc_entity_view"
|State-County   | psql -U postgres -c "SELECT * FROM rdaas.state_county_view"
|State          | psql -U postgres -c "SELECT * FROM rdaas.state_view"

### Database Specific Views

These views are related to the Database itself; size of db, schema,
and the revision of the RDaaS data schema.

|Name          |Command
| :---         |:---
|View List     | psql -U postgres -c "SELECT * FROM rdaas.view_list"
|Database Info | psql -U postgres -c "SELECT * FROM rdaas.database_info_view"
|Database Size | psql -U postgres -c "SELECT * FROM rdaas.db_size_view"
|Schema Size   | psql -U postgres -c "SELECT * FROM rdaas.schema_size_view"

### Performance Checking

Within any of the views above, or any query for that matter, you can prefix the
select statement with `EXPLAIN ANALYZE` to see the performance of the query.

Example: `rdaas.state_county_view`

```shell
psql -U postgres -c "explain analyze select * from rdaas.state_county_view"
```

| ![View List](docs/images/query-plan.PNG?raw=true) |
|:--:|
| *View List* |

### Update LoTW Data

As most know, LoTW released their `lotw-user-activity.csv` for public consumption.
This section shows you how `easy` it is to update the LoTW table. At present, there are over 124,000 calls in the CSV file. The query below limits the results to ten for display purposes.

```shell
# Change directory to lotw, and run the update
# Note: If the update is successful, "View" will list the top
# 15 or so callsigns according to date and time DESC

cd /d (C|D):\JTSDK-Tools\src\dotnet-core-examples\Database\rdaas\sql\lotw

# Run the update command:

wget -c https://lotw.arrl.org/lotw-user-activity.csv

# Call the LoTW Update SQL script

psql -v ON_ERROR_STOP=1 -U postgres -f lotw-import.sql
```

| ![LoTW Update](docs/images/lotw-update.PNG?raw=true) |
|:--:|
| *LoTW Update* |

## Next Phase

There are many more views and queries to be added. Have a look at `pgAdmin4` that
accompanies the installation. There are an unlimited number of actions you can do
with `pgAdmin4`.

The next step for the database itself is to finish adding views for the
remaining tables, then start looking at specific user-need queries and functions.

## Bug Reports

If you have problems with setting things up, or any of the steps in this brief guide,
please file a [Bug Report](https://github.com/KI7MT/dotnet-core-examples/issues)
on the Github Issue Tracker.

