/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 SingleTree.dll
 *  Description..: For Loop Single Tree
 */
using System;

namespace Beam.Example.Introductory.SingleTree
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
                // start first inner loop for spacing
                for (int sCount = 9; sCount > oCount - 1; sCount--)
                {
                    Console.Write(" ");
                }
                // end first inner loop

                // start second inner loop for "o"
                for (int iCount = 1; iCount <= (oCount + oCount - 1); iCount++)
                {
                    Console.Write("o", oCount);
                }
                // end second inner loop

                Console.WriteLine(); // print line spacing
            }
            // end outer loop

            // print footer
            Console.WriteLine();

        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.Introductory.SingleTree