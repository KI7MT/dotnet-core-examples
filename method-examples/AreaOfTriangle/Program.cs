/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Intermediate
 *  Target ......: netcoreapp2.0 InchesToCentimeters.dll
 *  Description..: Uses a method outside of Main to perform a calculation
 */
using System;

namespace Beam.Example.AreaOfTriangle
{
    class Program
    {
        #region Main Method

        static void Main(string[] args)
        {
            // console title
            Console.Title = "Area of Triangle";

            // clear screen
            Console.Clear();

            // method variables
            double inputBase;
            double inputHeight;
            double returnArea;

            // print header
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" Calculate the Area of a Triangle");
            Console.WriteLine("  1. Enter the Base Length");
            Console.WriteLine("  2. Enter the Height");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();

            // user input - base
            Console.Write(" Input Base .....: ");
            inputBase = Convert.ToDouble(Console.ReadLine());

            // user input - height
            Console.Write(" Input Height ...: ");
            inputHeight = Convert.ToDouble(Console.ReadLine());

            // call method to return area
            returnArea = CalcTriangleArea(inputBase, inputHeight);
            Console.WriteLine(" Triangle Area ..: {0}", returnArea);

            // Pause the results
            Console.WriteLine();
            Console.Write(" Press Any Key to Exit ... ");
            Console.ReadKey();
        }

        #endregion

        #region Area of Triangle
        
        static double CalcTriangleArea(double valueBase, double valueHeight)
        {
            // Formula: Area = one half the base times the width
            return 0.5 * valueBase * valueHeight;
        }

        #endregion

    } // END - class program

} // END - namespace Beam.Example.AreaOfTriangle
