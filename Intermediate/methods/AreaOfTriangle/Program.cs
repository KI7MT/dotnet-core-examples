/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 AreaOfTriangle.dll
 *  Description..: Uses a method outside of Main to perform a calculation
 */
using System;

namespace Beam.Example.Intermediate.AreaOfTriangle
{
    class Program
    {
        #region Main Method

        static void Main(string[] args)
        {
            // console title
            Console.Title = "Calculate Area of Triangle";

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
        }

        #endregion

        #region Method: Area of Triangle
        
        static double CalcTriangleArea(double valueBase, double valueHeight)
        {
            // Formula: Area = one half the base times the width
            return 0.5 * valueBase * valueHeight;
        }

        #endregion

    } // end class program

} // end namespace Beam.Example.Intermediate.AreaOfTriangle
