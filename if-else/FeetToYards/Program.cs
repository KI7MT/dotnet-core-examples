/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 FeetToYards.dll
 *  Description..: User Input feet => convert feet to yards
 */
using System;

namespace Beam.Example.FeetToYards
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double conversionFactor = 0.111111111;
            double squareFeetIn;
            double squareYardOut;

            Console.WriteLine();
            Console.Write(" Enter Square Feet ..: ");
            squareFeetIn = Convert.ToDouble(Console.ReadLine());

            // calculation
            squareYardOut = squareFeetIn * conversionFactor;

            // print results
            Console.Write(" Square yards .......: {0}\n", squareYardOut);
            Console.WriteLine();
            Console.Write(" Press Any Key to Exit...");
            Console.ReadKey();

        } // END - Main Method
    
    } // END - class Program

} // END - namespace Beam.Example.FeetToYards
