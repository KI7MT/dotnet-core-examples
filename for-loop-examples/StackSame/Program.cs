/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 StackDifferent.dll
 *  Description..: For Loop Stack Same Numbers Across
 */
using System;

namespace StackSame
{
    class Program
    {
        static void Main(string[] args)
        {
            // start outer loop
            for (int oCount = 1; oCount <= 9; oCount++)
            {
                // start inner loop
                for (int iCount = 1; iCount <= oCount; iCount++)
                {
                    Console.Write("{0} ", oCount);
                }
                // end inner loop

                Console.WriteLine(); // end of line return
            }
            // end outer loop

            // print footer
            Console.WriteLine();
            Console.Write("Press Any Key to Exit...");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.StackSame
