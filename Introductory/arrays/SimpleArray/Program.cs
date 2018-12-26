/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 SimpleArray.dll
 *  Description..: Simple 10 Element Array
 */
using System;
using System.Collections.Generic;

namespace Beam.Example.SimpleArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize the array with 10 elements
            double[] listValue = new double[10];

            // print header
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" Enter Ten Values For an Array.");

            // start loop - enter values into array
            Console.WriteLine();
            for (int iCount = 0; iCount < 10; iCount++)
            {
                Console.Write(" Enter Value ..: ");
                listValue[iCount] = Convert.ToDouble(Console.ReadLine());
            }
            // end loop

            // print array values in reverse order
            Console.WriteLine("");
            Console.WriteLine(" The values in reverse order are:");

            // start loop
            for (int oCount = 10 - 1; oCount >= 0; oCount--)
            {
                Console.WriteLine(" {0}", listValue[oCount]);
            }
            // end loop

            // print footer
            Console.WriteLine("\nFinished");

        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.SimpleArray