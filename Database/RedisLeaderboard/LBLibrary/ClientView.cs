using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LBLibrary
{
    public class ClientView
    {
        #region GetLeaderScore

        public static void GetLeaderScore(string host, int port, string password, int count, int sleep)
        {
            RedisUtils redisUtils = new RedisUtils(host, port, password);

            using (IRedisNativeClient client = redisUtils.GetNativeClient())
            {
                var counter = 1;
                if (count < 1)
                {
                    while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
                    {
                        counter = 1;
                        Common.DashLine();
                        Console.WriteLine($"Infinite Loop (3 seconds)");
                        Console.WriteLine($"Leaderboard - {DateTime.Now}");
                        Common.DashLine();

                        var timer1 = System.Diagnostics.Stopwatch.StartNew();
                        IDictionary<string, double> dic1 = redisUtils.GetClient().GetAllWithScoresFromSortedSet("leaderboard");

                        // Iterate through the Dictionary and Print Key, Value Pair
                        foreach (KeyValuePair<string, double> c in dic1.OrderByDescending(key => key.Value).Take(10))
                        {
                            var val1 = Convert.ToString(c.Key);
                            var val2 = Convert.ToString(c.Value);
                            Console.WriteLine($" {Convert.ToString(counter).PadRight(3)} {val1.PadRight(10)} {val2}");
                            counter++;
                        }

                        Common.DashLine();
                        Console.WriteLine($"Elapsed Time .. {Math.Round(timer1.Elapsed.TotalSeconds, 3)} sec.");
                        Console.WriteLine("Press ESC Key to Exit Loop\n");
                        Thread.Sleep(sleep);
                    }
                }
                else
                {
                    Common.DashLine();
                    Console.WriteLine($"One-Time Update");
                    Console.WriteLine($"Leaderboard - {DateTime.Now}");
                    Common.DashLine();
                    var timer1 = System.Diagnostics.Stopwatch.StartNew();
                    IDictionary<string, double> dic1 = redisUtils.GetClient().GetAllWithScoresFromSortedSet("leaderboard");
                    foreach (KeyValuePair<string, double> c in dic1.OrderByDescending(key => key.Value).Take(10))
                    {
                        var val1 = Convert.ToString(c.Key);
                        var val2 = Convert.ToString(c.Value);
                        Console.WriteLine($" {Convert.ToString(counter).PadRight(3)} {val1.PadRight(10)} {val2}");
                        counter++;
                    }
                    Common.DashLine();
                    Console.WriteLine($"Elapsed Time .. {Math.Round(timer1.Elapsed.TotalSeconds, 3)} sec.");

                } // end If - While - Else Loop

            } // end using IRedisNativeClient

        } // end GetLeaderScore

        #endregion

        #region TestFunctions && CodeSnippets (not fully functional)

        //// TypeOfEnums
        //string[] names = Enum.GetNames(typeof(Contest.LeaderBoards));
        //Random random = new Random();
        //int randomEnum = random.Next(names.Length);
        //var ret = Enum.Parse(typeof(Contest.LeaderBoards), names[randomEnum]);
        //Console.WriteLine(ret.ToString());

        //IList<string> lblist = Enum.GetNames(typeof(Contest.LeaderBoards));
        ////string[] names = Enum.GetNames(typeof(Contest.LeaderBoards));

        //Console.WriteLine("-------------------------------");
        //Console.WriteLine("Leader Board Availability");
        //Console.WriteLine("-------------------------------");
        //foreach (var item in lblist)
        //{
        //    Console.WriteLine(item);
        //}

        //for (int i = 0; i < lblist.Length; i++)
        //{
        //    Console.WriteLine(names[i]);
        //}

        //// Zscore -----------------------------------------------------------
        //using (IRedisClient client = redisUtils.GetClient()) ;
        //{
        //    var client = GetClient.As<Operator>();

        //    IList<string> myList = new List<string>(); // Example list.

        //    foreach (string value in myList)
        //    {
        //        byte[] value = client.ZScore("leaderboard", StringConversion.ByteToString(value));
        //        Console.WriteLine($"{value} {score}");
        //    }
        //}

        //// GetAllItemsFromSortedSet -----------------------------------------
        //using (IRedisNativeClient client = new RedisNativeClient(host, port, password))
        //{
        //    IList<string> myList = new List<string>(); // Example list.
        //    myList.Add("KI7MT");
        //    myList.Add("K1ABS");
        //    myList.Add("K1ABC");

        //    foreach (string callsign in myList)
        //    {
        //        double score = client.ZScore("leaderboard", RedisUtils.StringToByte(callsign));
        //        Console.WriteLine($"{callsign} {score}");
        //    }
        //}
        //using (IRedisClient client = redisUtil.GetClient())
        //{
        //    IList<string> mList = new List<string>(client.GetAllItemsFromSortedSet("leaderboard"));
        //    Console.WriteLine(mList.ToString());
        //}

        #endregion

    } // end class ClientView

} // end namspace LBBLibrary
