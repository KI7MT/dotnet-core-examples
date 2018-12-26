/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 Diamond.dll
 *  Description..: Double Triangle is a Diamond
 *
 *  Note: this approach uses (3) For Loops as opposed to (6). The IF statement
 *        controls counter direction (mCount) "as seen by" the two inner loops
 *        (sCount and oCount), in affect, reversing inner loop action after
 *        mCount reaches 10.
 *
 *  - mCount is the master (outer loop) counter ( 1 to 19 )
 *  - sCount is the space counter ( decrements when mCount <= 10 and increments when mCount > 10 )
 *  - oCount is the "o" counter ( increments when mCount <= 10 and decrements when mCount > 10 )
 *
 */
using System;

namespace beam.example.DoubleTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            int controlCount = 0;   // sets the variable for the IF statement
            int maxCount = 20;      // sets the maximum count value for dealing with the bottom triangle

            // start outer loop iteration of 1 to 19
            for (int mCount = 1; mCount <= 19; mCount++)
            {
                if (mCount <= 10)
                {
                    controlCount = mCount;  // (increments) "o's" and decrements spacing

                }
                else
                {
                    controlCount = (maxCount - mCount); // (decrements) "o's" and increments spacing
                }

                // start space Loop to generate number of " " for each line ( decrements <= 10, increments > 10 )
                for (int sCount = 9; sCount > controlCount - 1; sCount--)
                {
                    Console.Write(" ");
                }
                // end spacing loop

                // start counting loop for number of "o's" per line ( increments <= 10, decrements > 10 ), odd numbers only
                for (int oCount = 1; oCount <= (controlCount + controlCount - 1); oCount++)
                {
                    Console.Write("o", controlCount);
                }
                // end inner loop for "o's"

                // print line spacing
                Console.WriteLine();
            }
            // end outer loop

        } // end Main Method

    } // end lass Program

} // end namespace DoubleTriangle