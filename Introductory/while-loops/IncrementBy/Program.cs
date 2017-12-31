/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 IncrementBy.dll
 *  Description..: While loop that increments by x
 */
using System;

namespace Beam.Example.IncrementBy
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            int count = 47;

            // print header
            Console.WriteLine();
            Console.WriteLine(" Values for ( 47 thu 78 ) incremented by ( 4 )");
            Console.WriteLine();

            // start loop
            while (count < 78)
            {
                Console.WriteLine(" Number is now {0} ", count);
                count = count + 4;
            }

            // print footer
            Console.WriteLine();
            Console.WriteLine(" Press Any Key to Exit...");
            Console.ReadKey();


        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.IncrementBy
