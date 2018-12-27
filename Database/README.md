## Database .NET Core Examples

>NOTE: RedisLeaderboard is fully functional and rendering properly. Neo4J, however,
>queries need to be updated due to Database changes between version data-sets.
>At present, the queries render null results.

## ToDo List

* Add [Docker Installation](https://docs.docker.com/docker-for-windows/install/)
and basic use information with [Redis](https://docs.docker.com/samples/library/redis/)

## RedisLeaderboard Requirements

This application requires [Redis](https://redislabs.com/) running on default 
port => `localhost:6379`. If you have a remote server or running Redis on a
different port, update the `app_config` files in each assembly. Likewise,
the current password is set to NULL, which is the default installation `password`.

The easiest way to test `RedisLeaderboard` is by using a [Docker Redis Server]().
The example(s) below used a [Docker Container]() on a Win-10 x64 installation.

### Installation Methods for Redis

1. [Redis via Docker Container - Preferred]()
1. [Redis via Windows Subsystem Linux - Equally as good]()
1. [Native Linux Installaiton - Either Docker or Native install is fine]()

>NOTE: Running Redis on Linux is `not` recommended ([by the Redis Development team](https://redislabs.com/ebook/appendix-a/a-3-installing-on-windows/a-3-1-drawbacks-of-redis-on-windows/)).
>Therefore, any of the methods above would be a far better approach. If you opt for
>installing Redis on Windows natively, expect problems in the long-term.

### Windows Install Steps

1. `dotnet restore`
2. `make clean`
3. `make pack`
4. `make install`

### Linux Install Steps

1. `make`
2. `make install`

### Running the Service and Client (both are command-line)

```shell
# Open First Console and type:

LBService

1. Select Option 1 to Seed the DB
2. Select Incremental updates, or continuos loop
3. The last option will flush the key-store.

# Open a Second Console and type:

LBClient

1. Select Single update, or loop

# To stop loop-mode, use the ESC Key. This will take a few seconds as the
# sequence is set between 3 and 6 second updates (via app_config). At the break,
# you will be back to the main-menu, select Q to quit.
```

## Screen Shots and Base Application Information

### Redis Running via Docker Container

* Docker 5.0-Alpine Linux Image running Redis on `localhost:6379`
* `LBService` Running in a 6sec (set in app_config) continuos update-loop
* `LBClient` requesting updates every 3sec (set in app_config)
* Container footprint is only ~95MB in size
* Consoles are standard Windows CMD or Powershell
* Alpine Linux is a `barebones` Linux instance running in a container
* `No` system installing of Redis, nor Alpine Linux is required
* [Docker](https://docs.docker.com/docker-for-windows/install/) is the only System-Level Installation that is required

| ![Redis via Docker](docs/images/redis-via-docker.PNG?raw=true) |
|:--:|
| *Redis Running in Docker Container with a ~95MB Footprint* |

### Service Main Menu

1. Populates the Redis store with an initial set of `key-value` pairs
1. Does one round of incremental (random) numeric updates
1. Sets the `LBService` in an continuos update-mode
1. Cleans out (removes) the Redis store of all `key-value` pairs

| ![LBService Main Menu](docs/images/LBService.PNG?raw=true) |
|:--:|
| *LBService Main Menu* |

### LBService Looping Through Updates

>COMMENT: The time in this screen shot is a bit misleading. Each round of updates
>is read from a file `SeedList1.txt`; a random number assigned to each key; 
>each `key pair` is added to pipeline-push for Redis. The `entire process`
>takes, on average, 5sec which includes Read I/O, Random Number Generation and udpates to the Redis Store.

| ![LBService Loop](docs/images/LBService-Loop-Mode.PNG?raw=true) |
|:--:|
| *LBService in Loop Mode Updateing 123,625 Keys* |

#### LBClient Main Menu

1. `LBClient` requests a single update from Redis
1. `LBClient` requests continuos updates every 3sec form Redis

| ![Welcome Screen](docs/images/LBClient.PNG?raw=true) |
|:--:|
| *LBClient Main Menu*

#### LBClient Loop Mode

* Updates are set by `app_congif` before compile time.
* After `LBService` update, Redis generates a sorted-set, grouping by the top 10 scores.
* 1.3sec to parse 123K calls, sort them by score, and return the data

| ![Welcome Screen](docs/images/LBClient-Loop-Mode.PNG?raw=true) |
|:--:|
| *LBClient in Loop Mode*
