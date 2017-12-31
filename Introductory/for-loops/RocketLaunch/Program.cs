/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 RocketLaunch.dll
 *  Description..: For loop countdown
 */
using System;

namespace Beam.Example.RocketLaunch
{
    class Program
    {
        static void Main(string[] args)
        {
            // start loop
            for (int tCount = 11 - 1; tCount >= 1; tCount--)
            {
                Console.WriteLine();
                Console.Write(" Rocket launch in {0} seconds", tCount);
            }

            // print result
            Console.WriteLine("\n\n Blast Off!!");
            Console.WriteLine();

            // print footer
            Console.Write(" Press Any Key to Exit...");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.RocketLaunch
