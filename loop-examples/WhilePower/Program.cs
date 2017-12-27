/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 WhilePower.dll
 *  Description..: While loop that calculates powers of 10  for x < <= 10
 */
using System;

namespace Beam.Example.WhilePower
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            int x = 1;
            double power10;

            // print header
            Console.WriteLine();
            Console.WriteLine(" Values for ( 10 ^ x ) where ( x =< 10 )");
            Console.WriteLine();

            // start loop
            while (x <= 10)
            {
               power10 = Math.Pow(10, x);
               Console.WriteLine(" 10 to the power of {0} is {1}", x, power10.ToString("#,##0"));
               x++;
            }

            // print footer
            Console.WriteLine();
            Console.WriteLine(" Press Any Key to Exit...");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.WhilePower