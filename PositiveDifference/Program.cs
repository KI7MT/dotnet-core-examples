/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Description..: Determine the Absolute Value (Positive Difference)
 *                 between two numbers
 */
using System;

namespace Beam.Example.PositiveDifference
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
            Console.Write(" Press Any Key to Exit...");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.PositiveDifference