/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 AreaOfCylinder.dll
 *  Description..: Uses a method outside of Main to perform a calculation
 */
using System;

namespace Beam.Example.VolumeOfCylinder
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

            // method vaariables
            double inputDiameter;
            double inputHeight;
            double returnArea;

            // print header
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(" Calculate the Volume of a Cylinder");
            Console.WriteLine("  1. Enter Cylinder Diameter");
            Console.WriteLine("  2. Enter Cylinder Height");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            // user input - diameter
            Console.Write(" Input Cylinder Diameter ..: ");
            inputDiameter = Convert.ToDouble(Console.ReadLine());

            // user input - height
            Console.Write(" Input Cylinder Height ....: ");
            inputHeight = Convert.ToDouble(Console.ReadLine());

            // calculation by calling method
            returnArea = CalcCylinderVolume(inputDiameter, inputHeight);
            Console.WriteLine(" Volume of Cylinder .......: {0}", returnArea);

            // print footer
            Console.WriteLine();
            Console.Write(" Press Any Key to Exit ... ");
            Console.ReadKey();

        }

        #endregion

        #region Method: Volume of a Cylinder
        static double CalcCylinderVolume(double valueDiameter, double valueHeight, double valuePI = Math.PI)
        {
            // Formula: Volume = π * (Radius Squared) * h
            return valuePI * Math.Pow(valueDiameter / 2, 2) * valueHeight;
        }

        #endregion

    } // END - class Program

} // END - namespace Beam.Example.VolumeOfCylinder