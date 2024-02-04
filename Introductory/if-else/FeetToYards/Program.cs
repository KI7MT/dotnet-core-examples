/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: net8.0 FeetToYards.dll
 *  Description..: User Input feet => convert feet to yards
 */
using System;

namespace Beam.Example.Introductory.FeetToYards
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

        } // end Main Method
    
    } // end class Program

} // end Beam.Example.Introductory.FeetToYards
