/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: net8.0 PositiveDifference.dll
 *  Description..: Determine the Absolute Value (Positive Difference)
 *                 between two numbers
 */
using System;

namespace Beam.Example.Introductory.PositiveDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            //method variables
            double num1;
            double num2;
            double numDiff;

            // user input - No Input Validation
            Console.WriteLine();
            Console.WriteLine(" Find the positive difference of two numbers.\n");
            Console.Write(" Enter First Number ...: ");
            num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter Second Number ..: ");
            num2 = Convert.ToDouble(Console.ReadLine());

            // calculation
            numDiff = Math.Abs(num1 - num2);

            // print results
            Console.WriteLine();
            Console.Write(" Positive Difference ..: {0}\n", numDiff);
            Console.WriteLine();

        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.Introductory.PositiveDifference