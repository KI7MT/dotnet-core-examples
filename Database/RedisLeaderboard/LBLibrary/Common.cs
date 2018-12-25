using System;

namespace LBLibrary
{
    public static class Common
    {
        #region Convert byte[] to string

        /// <summary>
        /// Converts byte [] to string
        /// </summary>
        /// <param name="byteArray">byte [] bArray</param>
        /// <returns>string</returns>
        public static string ByteToString(byte[] byteArray)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetString(byteArray);
        }

        #endregion

        #region Convert string to byte []

        /// <summary>
        /// Converts string to byte []
        /// </summary>
        /// <param name="string1">String string value</param>
        /// <returns>byte []</returns>
        public static byte[] StringToByte(string string1)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(string1);
        }

        #endregion

        #region StarLine

        public static void StartLine()
        {
            Console.WriteLine("**************************************");
        }

        #endregion

        #region DashLine

        public static void DashLine()
        {
            Console.WriteLine("--------------------------------------");
        }

        #endregion

        #region MainMenuHeader

        public static void MainMenuHeader(string title)
        {
            DashLine();
            Console.WriteLine($"{title}");
            DashLine();
        }

        #endregion

        #region ClearScreen

        public static void ClearScreen()
        {
            Console.Clear();
        }

        #endregion

        #region UnderConstruction

        public static void UnderConstruction()
        {
            Console.WriteLine("** [ Feature Is Under Construction ] **\n");
        }

        #endregion

        #region PausePrompt

        public static void PausePrompt()
        {
            Console.Write("\nPress ENTER for manin menu ...");
            Console.ReadKey();
            ClearScreen();
        }

        #endregion

    } // end class Common

} // end namespace LeaderboardClient
