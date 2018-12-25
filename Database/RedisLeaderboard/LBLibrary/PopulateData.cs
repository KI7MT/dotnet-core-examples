using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.IO;
using System.Threading;
using ServiceStack.Redis;

namespace LBLibrary
{
    public class PopulateData
    {
        #region SeedFile
        /// <summary>
        /// Gets the path and name of Seed List File
        /// </summary>
        /// <returns>path to Seed List File</returns>
        public static string SeedFile
        {
            get
            {
                var fileName = ConfigurationManager.AppSettings["SourceList"];
                var prefix = System.Reflection.Assembly.GetEntryAssembly().Location;
                var directory = System.IO.Path.GetDirectoryName(prefix);
                var osSep = Path.DirectorySeparatorChar.ToString();
                return Path.Combine(directory + osSep + fileName);
            }
        }
        #endregion

        #region FlushDatabase

        public static void FlushDatabase(string host, int port, string password)
        {
            RedisUtils redisUtils = new RedisUtils(host, port, password);

            using (IRedisClient client = redisUtils.GetClient())
            {
                Console.WriteLine($"Flushing Database");
                Common.DashLine();
                client.FlushDb();
                Console.WriteLine($"Finished");
            }
        }

        #endregion

        #region AddItemToSet
        /// <summary>
        /// Generate Seed Data for Local C# testing
        /// Note: All Values are set to 0.0 initially
        /// </summary>
        /// <param name="host">Hostname of the server, set by Appconfig</param>
        /// <param name="port">Redis port, set by AppConfig</param>
        /// <param name="password">server password, set by AppConfig</param>
        public static void AddItemsToSet(string host, int port, string password)
        {
            RedisUtils redisUtils = new RedisUtils(host, port, password);

            // Use Pipeline to insert records into Redis
            using (var pipeline = redisUtils.GetClient().CreatePipeline())
            {
                var timer1 = System.Diagnostics.Stopwatch.StartNew();
                int d = 1;
                string value;
                string seedfile = SeedFile;

                //string source_list = ConfigurationManager.AppSettings["SourceList"];
                List<string> tempList = File.ReadLines(seedfile).ToList();

                // Count the number of items in the sorted set
                int c = tempList.Count;

                var timer2 = System.Diagnostics.Stopwatch.StartNew();
                Console.Write("* R => AddItemToSortedSet(*)\n");
                foreach (var item in tempList)
                {
                    value = timer1.ElapsedTicks.ToString();
                    Console.Write($"\r* Adding Keys .......: [ {d.ToString("N0")} ] ");
                    pipeline.QueueCommand(r => r.AddItemToSortedSet("leaderboard", item, 0));
                    d++;
                }
                pipeline.Flush();

                timer1.Stop();
                var elapsedMs = timer1.ElapsedMilliseconds;
                Console.WriteLine($"\n* Pipelined Keys ....: [ {c.ToString("N0")} ]");
                Console.WriteLine($"* Update Time .......: [ {Math.Round(timer2.Elapsed.TotalSeconds, 5)} ] sec.");
            }
        }
        #endregion

        #region IncrementSortedSet
        /// <summary>
        /// Update Seed Data for Local C# testing ** NOT FOR PRODUCTION **
        /// </summary>
        /// <param name="host">Hostname of the server, set by Appconfig</param>
        /// <param name="port">Redis port, set by AppConfig</param>
        /// <param name="password">server password, set by AppConfig</param>
        public static void IncrementSortedSet(string host, int port, string password)
        {
            RedisUtils redisUtils = new RedisUtils(host, port, password);

            using (IRedisClient client = redisUtils.GetClient())
            {
                using (var pipeline = redisUtils.GetClient().CreatePipeline())
                {
                    // proces variables
                    var timer1 = System.Diagnostics.Stopwatch.StartNew();
                    int d = 1;
                    string t2;
                    string value;
                    string seedFile = SeedFile;

                    // create the see list from source list file
                    // string source_list = ConfigurationManager.AppSettings["SourceList"];
                    List<string> callsigns = File.ReadLines(seedFile).ToList();

                    // Count the number of items in the sorted set
                    int c = callsigns.Count;

                    // start update loop
                    var timer2 = System.Diagnostics.Stopwatch.StartNew(); // This is the Redis update time portion
                    Console.Write("* R => IncrementItemInSortedSet(*)\n");
                    Console.WriteLine($"* Seed File Count ..: [ {c.ToString("N0")} ]");
                    foreach (var item in callsigns)
                    {
                        value = timer1.ElapsedTicks.ToString();
                        t2 = value.Substring(value.Length - 3); // 3 gets the last three digits ot ET in miliseconds
                        Console.Write($"\r* Updating Keys ....: [ {d.ToString("N0")} ] ");
                        pipeline.QueueCommand(r => r.IncrementItemInSortedSet("leaderboard", item, Convert.ToDouble(t2)));
                        d++;
                    }
                    pipeline.Flush(); // push the increments to Redis
                    timer1.Stop();    // stop the update timer
                    var elapsedMs = timer1.ElapsedMilliseconds;
                    Console.WriteLine($"\n* Pushed Keys ......: [ {c.ToString("N0")} ]");
                    Console.WriteLine($"* Update Time ......: [ {Math.Round(timer2.Elapsed.TotalSeconds, 5)} ]");
                } // END - Using Pipeline
            } // END - IRedisClient
        } // END - IncrementSortedSet

        #endregion

        #region IncrementData (Loop Wrapper class IncrementSortedSet)
        public static void IncrementData(string host, int port, string password, int count, int sleepT)
        {
            if (count < 1)
            {
                while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
                {
                    Console.WriteLine($"Update in Continious Loop");
                    Common.DashLine();
                    PopulateData.IncrementSortedSet(host, port, password);
                    Console.WriteLine($"* Sleeping .........: [ {sleepT / 1000} ] sec");
                    Common.DashLine();
                    Console.WriteLine($"Time Stamp - {DateTime.Now}");
                    Console.WriteLine("Press ESC Key to Exit Loop\n");
                    Thread.Sleep(sleepT);
                }
            }
            else
            {
                Console.WriteLine($"One-Time Update");
                Common.DashLine();
                PopulateData.IncrementSortedSet(host, port, password);
                Console.WriteLine($"* Sleeping .........: [ {sleepT / 1000} ] sec");
                Common.DashLine();
                Console.WriteLine($"Time Stamp - {DateTime.Now}");
            } // END - If - While - Else Loop
        } // END - IncrementData
        #endregion

        #region AddInitialData

        public static void AddInitalData(string host, int port, string password)
        {
            Console.WriteLine($"Adding Seed Data");
            Common.DashLine();
            PopulateData.AddItemsToSet(host, port, password);
            Common.DashLine();
            Console.WriteLine($"Time Stamp - {DateTime.Now}");
        } // END - AddInitalData

        #endregion

    } // end class PopulateData
} // end namespace LBLibrary
