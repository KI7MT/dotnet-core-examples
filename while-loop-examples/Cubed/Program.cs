/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 Cubed.dll
 *  Description..: While loop to calculate cubed values
 */
using System;

namespace Beam.Example.Cubed
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            int x = 1;
            double cubed;

            // print header
            Console.WriteLine();
            Console.WriteLine(" Values for 1 thru 10 cubed");
            Console.WriteLine();

            // start loop
            while (x <= 10)
            {
                cubed = Math.Pow(x, 3);
                Console.WriteLine(" {0} cubed is {1}", x, cubed);
                x++;
            }

            // print footer
            Console.WriteLine();
            Console.WriteLine(" Press Any Key to Exit...");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.Cubed

