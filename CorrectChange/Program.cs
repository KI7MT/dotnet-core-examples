/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Description..: Use Modulus to calculate correct change
 */
using System;

namespace Beam.Example.CorrectChange
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double inChange;
            double iQ1;
            double iQ2;
            double iD1;
            double iD2;
            double iN1;
            double iP1;

            // user input - No Input Validation
            Console.WriteLine();
            Console.Write(" Enter Number of Cents ..: ");
            inChange = Convert.ToDouble(Console.ReadLine());

            // calculations
            iQ1 = inChange / 25;
            iQ2 = inChange % 25;
            iD1 = iQ2 / 10;
            iD2 = iQ2 % 10;
            iN1 = iD2 / 5;
            iP1 = iD2 % 5;

            // print results
            Console.WriteLine();
            Console.WriteLine(" Quarters ..: {0}", Math.Truncate(iQ1));
            Console.WriteLine(" Dimes .....: {0}", Math.Truncate(iD1));
            Console.WriteLine(" Nickles ...: {0}", Math.Truncate(iN1));
            Console.WriteLine(" Pennies  ..: {0}", iP1);
            Console.WriteLine();
            Console.Write(" Press Any Key To Exit...");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace com.beam.example.CorrectChange