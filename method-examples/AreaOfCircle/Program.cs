/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 AreaOfCircle.dll
 *  Description..: Uses a method outside of Main to perform a calculation
 */
using System;

namespace Beam.Example.AreaOfCircle
{
    class Program
    {

        #region Main Method

        static void Main(string[] args)
        {
            // console title
            Console.Title = "Calculate Area of Circle";

            // clear screen
            Console.Clear();

            // method variables
            double inputDiameter;
            double returnArea;

            // Display program header
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" Calculate the Area of a Circle");
            Console.WriteLine("  1. Enter Circle Diameter");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();

            // user input - diameter
            Console.Write(" Input Diameter ..: ");
            inputDiameter = Convert.ToDouble(Console.ReadLine());

            // calculation
            returnArea = CalcCircleArea(inputDiameter);
            Console.WriteLine(" Area of Circle ..: {0}", returnArea);

            // print footer
            Console.WriteLine();
            Console.Write(" Press Any Key to Exit ... ");
            Console.ReadKey();
        }

        #endregion

        #region Method: Area of Circle

        static double CalcCircleArea(double valueDiameter, double valuePI = Math.PI)
        {
            // Formula: Area = π * Radius Squared
            return valuePI * Math.Pow(valueDiameter / 2, 2);
        }

        #endregion

    } // END - class Program

} // END - namespace Beam.Example.AreaOfCircle