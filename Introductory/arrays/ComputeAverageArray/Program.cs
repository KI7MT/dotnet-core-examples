/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 ComputAverageArray.dll
 *  Description..: 1). Computes the average of all values in an array
 *                 2). Prints all values that are grater than the average
 */
using System;

namespace ComputeAverageArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double averageValue = 0;
            double sumValues = 0;

            // initialize array with 5 elements
            double[] listValue = new double[5];

            // print header
            Console.WriteLine();
            Console.WriteLine(" Enter Five Values For an Array.");
            Console.WriteLine();

            // start entering values and sum
            for (int iCount = 0; iCount < 5; iCount++)
            {
                Console.Write(" Enter Value .....: ");
                listValue[iCount] = Convert.ToDouble(Console.ReadLine());
                sumValues += listValue[iCount];
            }
            // end loop

            // average computation
            Console.WriteLine("");
            averageValue = sumValues / listValue.Length;
            
            // print result
            Console.WriteLine(" The average is ..: {0}", averageValue);

            // print average message
            Console.WriteLine("");
            Console.WriteLine(" The following are greater than the average:");
            
            // start average check loop
            for (int gCount = 0; gCount < 5; gCount++)
            {
                if (listValue[gCount] > averageValue)
                {
                    Console.WriteLine(" {0}", listValue[gCount]);
                }
            }
            // end loop

            // print footer
            Console.WriteLine("\nFinished");

        } // end Main Method

    } // end class Program

} // endnamespace Beam.Example.ComputeAverayArray