/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Description..: User Input Leagues => convert Leagues to Nautical Miles
 */
using System;

namespace Beam.Example.LeaguesToNauticalMiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double conversionFactor = 3.0000;
            double leaIn;
            double nmOut;

            // user input - No Input Validation
            Console.WriteLine();
            Console.Write(" Enter Number of Leagues ..: ");
            leaIn = Convert.ToDouble(Console.ReadLine());

            // calculation
            nmOut = leaIn * conversionFactor;

            // print result
            Console.Write(" Nautical Miles ...........: {0}\n", nmOut);
            Console.WriteLine();
            Console.Write(" Press Any Key To Exit...");
            Console.ReadKey();

        } // END - Main Method
    
    } // END - class Program

} // END - namespace Beam.Example.LeaguesToNauticalMiles