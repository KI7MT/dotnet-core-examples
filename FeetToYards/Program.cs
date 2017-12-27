/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Description..: User Input feet => convert feet to yards
 */
using System;

namespace Beam.Example.FeetToYards
{
    class Program
    {
        static void Main(string[] args)
        {
            double conversionFactor = 0.111111111;
            double squareFeetIn;
            double squareYardOut;

            Console.WriteLine();
            Console.Write(" Enter Square Feet ..: ");
            squareFeetIn = Convert.ToDouble(Console.ReadLine());
            squareYardOut = squareFeetIn * conversionFactor;

            // print the data
            Console.Write(" Square yards .......: {0}\n", squareYardOut);
            Console.WriteLine();
            Console.Write(" Press Any Key to Exit...");
            Console.ReadKey();

        } // END - Main Method
    
    } // END - class Program

} // END - namespace FeetToYards
