## Intermediate .NET Core Examples

>NOTE: RedisLeaderboard is function, as is Neo4J, however, Neo4J queries need
to be updated due to Dayabase changes between version data sets.

## TODO

* Full explanation of `LBService` and `LBClient` for `RedisLeaderboard`

## To run the Redis Leaderboard

* Requires Redis running on default port => localhost:6379
* `dotnet restore`
* `make clean`
* `make pack`
* `make install`

```shell
# Open First Console and type:

LBService

1. Select Option 1 to Seed the DB
2. Select Incremental updates, or continuos loop
3. The last option will flush the key-store.

# Open a Second Console and type:

LBClient

1. Select Single update, or loop

# To Stop the loop mode, use the ESC Key. Tis will take a few seconds as the
# sequence is set between 3 and 6 second updates. At the break, you'll be
# back to the menu, select Q to quit.
```