/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.2 Happy.dll
 *  Description..: While (true) loop Happy
 */
using System;

namespace Beam.Example.Introductory.Happy
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            string input;

            // print header
            Console.WriteLine();
            Console.Write(" Are You Happy? ( 1=yes, 2=no ): ");

            // start loop
            while (true)
            {
                input = Console.ReadLine();

                if (input == "1")  // answer if yes
                {
                    Console.WriteLine();
                    Console.WriteLine(" I am happy to hear that.");
                    break;
                }
                else if (input == "2") // answer if no
                {
                    Console.WriteLine();
                    Console.WriteLine(" I am sorry to hear that.");
                    break;
                }
                else // re-post the question if not 1 or 2
                {
                    Console.Write(" Please try again. Are you happy? ( 1=yes, 2=no): ");
                }
            }

            // print footer
            Console.WriteLine();
        
        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.Introductory.Happy