﻿/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Intermediate
 *  Target ......: net8.0 VolumeOfCylinder.dll
 *  Description..: Uses a method outside of Main to perform a calculation
 */
using System;

namespace Beam.Example.Intermediate.VolumeOfCylinder
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
            double inputDiameter;
            double inputHeight;
            double returnArea;

            // print header
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" Calculate the Volume of a Cylinder");
            Console.WriteLine("  1. Enter Cylinder Diameter");
            Console.WriteLine("  2. Enter Cylinder Height");
            Console.WriteLine("------------------------------------------------");
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
        }

        #endregion

        #region Method: Volume of a Cylinder
        
        static double CalcCylinderVolume(double valueDiameter, double valueHeight, double valuePI = Math.PI)
        {
            // Formula: Volume = π * (Radius Squared) * h
            return valuePI * Math.Pow(valueDiameter / 2, 2) * valueHeight;
        }

        #endregion

    } // end class Program

} // end namespace Beam.Example.Intermediate.VolumeOfCylinder