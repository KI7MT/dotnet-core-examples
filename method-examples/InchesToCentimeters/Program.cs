/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 InchesToCentimeters.dll
 *  Description..: Uses a method outside of Main to perform a calculation
 */
using System;

namespace Beam.Example.InchesToCentimeters
{
    class Program
    {
        #region Main Method

        static void Main(string[] args)
        {
            // console title
            Console.Title = "Convert Inches to Centimeters";

            // method variables
            double inputInches;
            double inputConversion = 2.54;
            double returnCentimeters;

            // print header
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(" Inch to centimeters Calculator Using Methods");
            Console.WriteLine("  1. Enter a number to convert");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            // input inches
            Console.Write(" Input Inches ........: ");
            inputInches = Convert.ToDouble(Console.ReadLine());

            // call the method to perform conversion
            returnCentimeters = ConvertInchesToCentimeters(inputInches, inputConversion);
         
            // print results
            Console.WriteLine(" Output Centimeters ..: {0}", returnCentimeters);

            // print footer
            Console.WriteLine();
            Console.Write(" Press Any Key to Exit ... ");
            Console.ReadKey();

        }

        #endregion

        #region Method: Convert Inches to Centimeters

        static double ConvertInchesToCentimeters(double valueInches, double convFactor)
        {
            // Formula: Centimeters = Inches * 2.54
            return valueInches * convFactor;
        }

        #endregion

    } // END - class Program

} // END - namespace Beam.Example.InchesToCentimeters