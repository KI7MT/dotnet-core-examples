/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.2 PowerOf.dll
 *  Description..: While loop that calculates powers of 10  for x < <= 10
 */
using System;

namespace Beam.Example.Introductory.PowerOf
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

        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.Introductory.PowerOf