/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: net8.0 StackSame.dll
 *  Description..: For Loop Stack Same Numbers Across
 */
using System;

namespace Beam.Example.Introductory.StackSame
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

        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.Introductory.StackSame