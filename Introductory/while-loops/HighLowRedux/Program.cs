/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 HighLowRedux.dll
 *  Description..: While loop for simple high-low guess game
 */
using System;

namespace Beam.Example.HighLowRedux
{
    class Program
    {
        static void Main(string[] args)
        {
            // random instance
            Random random = new Random();
            
            // method variables
            int secretNumber = random.Next(0, 1001);
            int guessCount = 0;
            int guessValue = -1;

            // print header
            Console.WriteLine();
            Console.Write(" High-Low Redux - Guess the value between ( 0 and 1000 )");
            Console.WriteLine();
            Console.WriteLine();

            // uncomment the next line to display Secret Number
            // Console.WriteLine(secretNumber);

            // start loop
            while (guessValue != secretNumber)
            {
                Console.Write(" Please enter a value for Guess ..: ");
                guessValue = Convert.ToInt16(Console.ReadLine());
                guessCount++;

                if (guessValue < secretNumber)
                {
                    Console.WriteLine(" HIGHER than {0}", guessValue);
                }
                else
                {
                    if (guessValue == secretNumber)
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine(" LOWER than {0}", guessValue);
                    }
                }
            }
            // print results
            Console.WriteLine(" CORRECT!");
            Console.WriteLine(" It took your {0} guesses", guessCount);
            Console.WriteLine();

            // print footer
            Console.WriteLine(" Press Any Key to Exit...");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.HighLowRedux