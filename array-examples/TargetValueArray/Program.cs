/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 ComputAverageArray.dll
 *  Description..: 1). Enter 10 values into an array
 *                 2). Count the number of times the target appears in the array
 */
using System;

namespace Beam.Example.TargetValueArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            int targetCount = 0;
            double targetValue = 0;

            // initialize the array with 10 elements
            double[] listValue = new double[10];

            // print header
            Console.WriteLine();
            Console.WriteLine(" Enter Ten Values For an Array.");

            // start input loop
            Console.WriteLine();
            for (int iCount = 0; iCount < 10; iCount++)
            {
                Console.Write(" Enter Value ...: ");
                listValue[iCount] = Convert.ToDouble(Console.ReadLine());
            }
            // end loop

            // enter target value
            Console.WriteLine();
            Console.Write(" Enter Target Value ..: ");
            targetValue = Convert.ToDouble(Console.ReadLine());

            // start target search loop
            for (int tCount = 0; tCount < 10; tCount++)
            {
                if (listValue[tCount] == targetValue)
                {
                    targetCount++;
                }
            }
            // end loop

            // print results
            Console.WriteLine();
            Console.WriteLine(" The target value [ {0} ] appears [ {1} ] times int the array.", targetValue, targetCount);
            Console.WriteLine();

            // print footer
            Console.WriteLine();
            Console.Write(" Press Any Key to Exit ... ");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.TargetValueArray
