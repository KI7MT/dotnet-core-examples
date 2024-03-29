﻿/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: net8.0 LargestNumber.dll
 *  Description..: While loop entry, print largest number
 */
using System;

namespace Beam.Example.Introductory.LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            int numControl = 0;
            int largestNumber = 0;

            // print header
            Console.WriteLine();
            Console.WriteLine(" Enter A Series of Positive Integers.");
            Console.WriteLine(" To exit the loop, enter: -1");
            Console.WriteLine();

            // start loop
            while (numControl != -1)
            {
                Console.Write(" Enter a Positive Integer ..: ");
                numControl = Convert.ToInt16(Console.ReadLine());

                if (numControl > 0)
                {
                    if (numControl > largestNumber)
                    {
                        largestNumber = numControl;
                    }
                }
            } // end loop

            // print results
            Console.WriteLine();
            Console.WriteLine(" Largest value was .........: {0}", largestNumber);

            // print footer
            Console.WriteLine();
            
        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.Introductory.LargestNumber