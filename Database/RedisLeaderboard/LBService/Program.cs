using System;
using System.Configuration;
using LBLibrary;

namespace LBService
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Database Connection and Instantiation Variables

            // Redis Connetion params via App.config
            string host = ConfigurationManager.AppSettings["RedisHost"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["RedisPort"]);
            string password = ConfigurationManager.AppSettings["RedisPassword"];

            // General Purpose AppConfig Values
            int serverSleepInterval = Convert.ToInt32(ConfigurationManager.AppSettings["ServerSleepInterval"]);
            int serverUpdateLoopCount = Convert.ToInt32(ConfigurationManager.AppSettings["ServerUpdateLoopCount"]);

            #endregion

            // Start Main Loop
            char choice;
            for (; ; )
            {
                do
                {
                    Common.ClearScreen();
                    Common.MainMenuHeader("Leaderboard Main Menu");
                    Console.WriteLine("\nServer Utilities");
                    Console.WriteLine("  1. Populate Sorted Set");
                    Console.WriteLine("  2. Increment Sorted Set");
                    Console.WriteLine("  3. Infinite Loop Update");
                    Console.WriteLine("  4. Flush Database");
                    Common.DashLine();
                    Console.Write("Choose one (q to quit): ");
                    do
                    {
                        choice = (char)Console.Read();
                    } while (choice == '\n' | choice == '\r');
                } while (choice < '1' | choice > '6' & choice != 'q');

                if (choice == 'q') break;

                Console.WriteLine("\n");

                switch (choice)
                {
                    case '1': // Add inital Sorted Set Data
                        Common.ClearScreen();
                        PopulateData.AddInitalData(host, port, password);
                        Common.PausePrompt();
                        break;
                    case '2': // Increment Sorted Set Data One Time
                        Common.ClearScreen();
                        PopulateData.IncrementData(host, port, password, serverUpdateLoopCount, serverSleepInterval);
                        Common.PausePrompt();
                        break;
                    case '3': // Infinite Loop Sorted Set Data Update
                        Common.ClearScreen();
                        PopulateData.IncrementData(host, port, password, 0, serverSleepInterval);
                        break;
                    case '4': // FlushDB
                        Common.ClearScreen();
                        PopulateData.FlushDatabase(host, port, password);
                        Common.PausePrompt();
                        break;
                    default:
                        Common.ClearScreen();
                        Common.PausePrompt();
                        break;
                } // end Switch

            } // end ForLoop

        } // end Main Method

    } // end class Program

} // end namespace LBServer