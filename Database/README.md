## Database .NET Core Examples

>NOTE: RedisLeaderboard is fully functional and rendering properly. Neo4J, however,
>queries need to be updated due to Database changes between version data-sets.
>At present, the queries render null results.

## ToDo

* Full explanation of `LBService` and `LBClient` for `RedisLeaderboard`

## To run the Redis Leaderboard

Requires Redis running on default port => localhost:6379. If you have a remote
server or running Redis on a different port, update the `app_config` files
in each assembly. Likewise, the current password is set to NULL, which is the
default installation `password`.

### Install Steps

1. `dotnet restore`
2. `make clean`
3. `make pack`
4. `make install`

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
# sequence is set between 3 and 6 second updates (app.config). At the break,
# you will be back to the main-menu, select Q to quit.
```