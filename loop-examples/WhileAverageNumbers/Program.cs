/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 WhileAverageNumbers.dll
 *  Description..: Average a series of Even and Odd numbers
 */
using System;

namespace Beam.Example.WhileAverageNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            int numControl = 0;
            int oddCount = 0;
            int evenCount = 0;
            double evenNumber = 0;
            double evenAverage = 0;
            double oddNumber = 0;
            double oddAverage = 0;

            // print header
            Console.WriteLine();
            Console.WriteLine(" Enter a series of Even and Odd numbers.");
            Console.WriteLine(" To exit the loop, enter: -1");
            Console.WriteLine();

            // start loop
            while (numControl != -1)
            {
                Console.Write(" Enter a number ...: ");
                numControl = Convert.ToInt16(Console.ReadLine());

                // logic for Even or Odd number
                if (numControl % 2 == 0)
                {
                    if (numControl > 0)
                    {
                        evenNumber = evenNumber + numControl;  // if > 0 add to even numbers and increment counter
                        evenCount++;
                    }
                }
                else
                {
                    if (numControl > 0)
                    {
                        oddNumber = oddNumber + numControl;  // if > 0 add to odd numbers and increment counter
                        oddCount++;
                    }
                }
            }

            // process even numbers
            if (evenNumber > 0)
            {
                evenAverage = evenNumber / evenCount;
            }
            else
            {
                evenAverage = evenNumber;
            }

            // process odd numbers
            if (oddNumber > 0)
            {
                oddAverage = oddNumber / oddCount;
            }
            else
            {
                oddAverage = oddNumber;
            }

            // print results
            Console.WriteLine();
            Console.WriteLine(" Even average is ..: {0}", evenAverage);
            Console.WriteLine(" Odd average is ...: {0}", oddAverage);
            Console.WriteLine();
            Console.WriteLine(" Press Any Key to Exit...");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.WhileAverageNumbers