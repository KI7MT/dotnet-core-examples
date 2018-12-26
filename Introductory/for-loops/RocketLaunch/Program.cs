/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.2 RocketLaunch.dll
 *  Description..: For loop countdown
 */
using System;

namespace Beam.Example.Introductory.RocketLaunch
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

        } // end Main Method

    } // end class Program

} // end Beam.Example.Introductory.RocketLaunch
