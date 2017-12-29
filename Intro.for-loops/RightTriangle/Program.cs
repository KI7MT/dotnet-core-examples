/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 RightTriangle.dll
 *  Description..: For Loop Right Triangle
 */
using System;

namespace Beam.Example.RightTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            // oCount is the outer loop counter, contains two nested loops ( sCount and iCount )
            // sCount is the spacing loop
            // iCount is the inner loop which adds the "o's"

            // start outer loop
            for (int oCount = 1; oCount <= 10; oCount++)
            {
               // start first inner loop (decrement)
               for (int sCount = 9; sCount > oCount - 1; sCount--)
               {
                   Console.Write(" "); // spacing
               }
               // end first inner loop

               // second inner loop (increment)
               for (int iCount = 1; iCount <= oCount; iCount++)
               {
                   Console.Write("o", oCount); // prints the "o"
               }
               // end second inner loop

               Console.WriteLine(); // line spacing
            
            }
            // end outer loop

            // print footer
            Console.WriteLine();
            Console.Write("Press Any Key to Exit... ");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.RightTriangle
