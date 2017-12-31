/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Advanced
 *  Target ......: netcoreapp2.0 TicTacToe.dll
 *  Description..: Simple Command Line Tic-Tac-Toe Game
 *                 Uses: 2D Arrays, If, If-Else, While-Loops
 *                       methods, and colors
 */
using System;
using System.Linq;

namespace Beam.Example.Advanced.TicTacToe
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // console title
            Console.Title = "Console Tic-Tac-Toe Game";

            // clear screen
            Console.Clear();

            // method variables
            int currentPlayer = 1;
            int lastPlayer = 0;
            int moveCounter = 0;
            int xCorr;
            int yCorr;

            bool gameStatus = false;

            string inputX = "";
            string inputY = "";
            string p1Name = "Player-1 ( X )";
            string p2Name = "Player-2 ( O )";
            string playerName;

            // method - populate main board array spaceing
            PopulateArray();

            // start main loop
            while (!gameStatus)
            {
                // method - print header 
                PrintHeader();

                // method - print the main board
                MainBoard();

                // method - check for tie-game if not game winner
                if (moveCounter == 9 & !CheckGameWinner())
                {
                    // method - check for tie game
                    TieGameMessage();
                    gameStatus = true;
                }
                // method - check for "winner winner turkey dinner"
                else if (!CheckGameWinner() & !gameStatus)
                {
                    // player naming 
                    if (currentPlayer == 1)
                    {
                        playerName = p1Name;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        playerName = p2Name;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }

                    // X and Y coordinate entry ( protects against null and string entry values )
                    Console.WriteLine();
                    Console.WriteLine("    {0} ", playerName);
                    Console.WriteLine("    Use (X,Y) Coordinates For Moves");
                    Console.Write("    Enter X Coordinate : ");
                    inputX = Console.ReadLine();
                    Console.Write("    Enter Y Coordinate : ");
                    inputY = Console.ReadLine();

                    // check for NULL values first
                    if (inputX.Length != 0 & inputY.Length != 0)
                    {
                        // check entry is [0, 1 or 2]
                        if (goodValues.Contains(inputX) & goodValues.Contains(inputY))
                        {
                            xCorr = Convert.ToInt32(inputX);
                            yCorr = Convert.ToInt32(inputY);

                            // check slot selection and switch users
                            if (pArray[xCorr, yCorr] != "X" & pArray[xCorr, yCorr] != "O")
                            {
                                // set array entry to X
                                if (currentPlayer == 1)
                                {
                                    pArray[xCorr, yCorr] = "X";
                                    currentPlayer = 0;
                                    lastPlayer = 1;
                                    moveCounter++;
                                }
                                // set array entry to O
                                else
                                {
                                    pArray[xCorr, yCorr] = "O";
                                    currentPlayer = 1;
                                    lastPlayer = 0;
                                    moveCounter++;
                                }
                            }
                            // innvlad move error message, slot is taken
                            else
                            {
                                // method
                                InvalidMoveMessage(xCorr, yCorr);
                            }
                        }
                        // invalid entry error essage, x or y needs to be between [ 0 and 2 ]
                        else
                        {
                            // method
                            InvalidEntryMessage(inputX, inputY);
                        }
                    }
                    // null value error message
                    else
                    {
                        // method
                        NullEntryMessage();
                    }
                } 
                // display winner information
                else
                {
                    // invert player name for winner
                    if (lastPlayer == 0)
                    {
                        playerName = p2Name;
                    }
                    else
                    {
                        playerName = p1Name;
                    }
                    // method - winner message
                    WinnerMessage(playerName);
                    gameStatus = true;

                }// end - entry section

            }// end - while loop
            
            // print footer
            Console.Write("\n    Press any key to exit...");
            Console.ReadKey();

        } // end - main method

        // ---------------------------------------------------------------------
        // BEGIN: METHODS
        // ---------------------------------------------------------------------

        // method - header
        static void PrintHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("       * Player-1 = X");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("       * Player-2 = O");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------");
            Console.ResetColor();
        }

        // method - main board array
        private static string[,] pArray = new string[3, 3];

        // acceptable input array of values for  (x, y) coordinates
        private static string[] goodValues = { "0", "1", "2"};

        // method - populate the board array with spaces for better appearance
        static void PopulateArray()
        {
            // top row, left to right
            string pos0 = pArray[0, 0] = " ";
            string pos1 = pArray[1, 0] = " ";
            string pos2 = pArray[2, 0] = " ";

            // middle row, left to right
            string pos3 = pArray[0, 1] = " ";
            string pos4 = pArray[1, 1] = " ";
            string pos5 = pArray[2, 1] = " ";

            // bottom row, left to right
            string pos6 = pArray[0, 2] = " ";
            string pos7 = pArray[1, 2] = " ";
            string pos8 = pArray[2, 2] = " ";
        }

        // method - draw main board
        static void MainBoard()
        {
            Console.WriteLine();
            Console.WriteLine("        0      1     2");
            Console.WriteLine("    +------+------+------+");
            Console.WriteLine("    |      |      |      |");
            Console.WriteLine("  0 |   {0}  |   {1}  |  {2}   |", pArray[0,0], pArray[1,0], pArray[2,0]);
            Console.WriteLine("    |      |      |      |");
            Console.WriteLine("    +------+------+------+");
            Console.WriteLine("    |      |      |      |");
            Console.WriteLine("  1 |   {0}  |   {1}  |  {2}   |", pArray[0,1], pArray[1,1], pArray[2,1]);
            Console.WriteLine("    |      |      |      |");
            Console.WriteLine("    +------+------+------+");
            Console.WriteLine("    |      |      |      |");
            Console.WriteLine("  2 |   {0}  |   {1}  |  {2}   |", pArray[0,2], pArray[1,2], pArray[2,2]);
            Console.WriteLine("    |      |      |      |");
            Console.WriteLine("    +------+------+------+");
        }

        // method - check for "winner winner chicken dinner"
        static bool CheckGameWinner()
        {
            // top row, left to right
            if (pArray[0,0] == pArray[1,0] & pArray[1,0] == pArray[2,0] & pArray[1,0] != " ")
            {
                return true;
            }
            // middle row, left to right
            else if (pArray[0,1] == pArray[1,1] & pArray[1,1] == pArray[2,1] & pArray[1,1] != " ")
            {
                return true;
            }
            // bottom row, left to right
            else if (pArray[0, 2] == pArray[1,2] & pArray[1,2] == pArray[2, 2] & pArray[1,2] != " " )
            {
                return true;
            }
            // left column, top to bottom
            else if (pArray[0,0] == pArray[0,1] & pArray[0,1] == pArray[0,2] & pArray[0,1] != " ")
            {
                return true;
            }
            // center column, top to bottom
            else if (pArray[1,0] == pArray[1,1] & pArray[1,1] == pArray[1,2] & pArray[1,1] != " ")
            {
                return true;
            }
            // right column, top to bottom
            else if (pArray[2,0] == pArray[2,1] & pArray[2,1] == pArray[2,2] & pArray[2,1] != " ")
            {
                return true;
            }
            // diagonal, top left to bottom right
            else if (pArray[0,0] == pArray[1,1] & pArray[1,1] == pArray[2,2] & pArray[1,1]  != " ")
            {
                return true;
            }
            // diagonal, bottom left to top right
            else if (pArray[0,2] == pArray[1,1] & pArray[1,1] == pArray[2,0] & pArray[1,1] != " ")
            {
                return true;
            }
            // return false if no winner
            else
            {
                return false;
            }
        }

        // method - invalid entry message
        static void InvalidEntryMessage(string inputX, string inputY)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n    Invalid Entry: ({0},{1}) Please Use (0, 1, 2) only", inputX, inputY);
            Console.Write("    Press any key to reload the board...");
            Console.ReadKey();
            Console.ResetColor();
        }

        // method - invalid move, slot is already taken
        static void InvalidMoveMessage(int xCorr, int yCorr)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n    Invalid Move: Position ({0},{1}) is already taken.", xCorr, yCorr);
            Console.Write("    Press any key to reload the board ...");
            Console.ReadKey();
            Console.ResetColor();
        }

        // method - disply error message when an x or y coordinate is NULL
        static void NullEntryMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n    Coordinate entries cannot be NULL");
            Console.Write("   Press any key to re-enter...");
            Console.ReadKey();
            Console.ResetColor();
        }

        // method - display winner message
        static void WinnerMessage(string playerName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n    WINNER : {0} ", playerName);
            Console.ResetColor();
        }

        // method - display tie-game message
        static void TieGameMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    TIE-GAME, NO WINNER");
            Console.ResetColor();
        }

    } // END - class Program

} // END - Beam.Example.Advanced.TicTacToe
