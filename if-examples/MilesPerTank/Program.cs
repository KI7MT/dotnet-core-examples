/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 MilesPerTank.dll
 *  Description..: Calculate Miles per Tank of Fuel
 */
using System;

namespace Beam.Example.MilesPerTank
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double tankSize;
            double milesTravelled;
            double gallonsLeft;
            double mpgOut;
            double milesPerTank;

            // user input - No Input Validation
            Console.WriteLine();
            Console.Write(" Enter Tank Size ........: ");
            tankSize = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter Miles Travelled ..: ");
            milesTravelled = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter Gallons Left .....: ");
            gallonsLeft = Convert.ToDouble(Console.ReadLine());

            // calculations
            mpgOut = milesTravelled / (tankSize - gallonsLeft);
            milesPerTank = mpgOut * tankSize;

            // print results
            Console.WriteLine();
            Console.WriteLine(" Miles per Full Tank ....: {0}", milesPerTank);
            Console.WriteLine();
            Console.Write(" Press Any Key To Exit...");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.MilesPerTank