using System;
using System.Configuration;
using LBLibrary;

namespace LBClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Database Connection and instantiation Variables

            // Redis Config parameters via App.config
            string host = ConfigurationManager.AppSettings["RedisHost"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["RedisPort"]);
            string password = ConfigurationManager.AppSettings["RedisPassword"];

            // Client config options via App.config
            int clientUpdateLoopCount = Convert.ToInt32(ConfigurationManager.AppSettings["ClientUpdateLoopCount"]);
            int clientSleepInterval = Convert.ToInt32(ConfigurationManager.AppSettings["ClientSleepInterval"]);

            #endregion

            // Start Main Loop
            char choice;
            for (; ; )
            {
                do
                {
                    Common.ClearScreen();
                    Common.MainMenuHeader("Leaderboard Main Menu");
                    Console.WriteLine("\nClient Utilities");
                    Console.WriteLine("  1. Leaderboard");
                    Console.WriteLine("  2. Infinite Loop Leaderboard\n");
                    Common.DashLine();
                    Console.Write("Choose one (q to quit): ");
                    do
                    {
                        choice = (char)Console.Read();
                    } while (choice == '\n' | choice == '\r');
                } while (choice < '1' | choice > '2' & choice != 'q');

                if (choice == 'q') break;

                Console.WriteLine("\n");

                switch (choice)
                {
                    case '1': // Leaderboard query (1,0) is used
                        Common.ClearScreen();
                        ClientView.GetLeaderScore(host, port, password, 1, 0);
                        Common.PausePrompt();
                        break;
                    case '2': // Infinate Leaderboard Query (0, clientSleepInterval)
                        Common.ClearScreen();
                        ClientView.GetLeaderScore(host, port, password, 0, clientSleepInterval);
                        break;
                    default:
                        Common.ClearScreen();
                        Common.PausePrompt();
                        break;
                } // end Switch

            } // end ForLoop

        } // end Main Method

    } // end class Program

} // end namespace LBClient