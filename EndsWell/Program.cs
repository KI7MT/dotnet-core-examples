/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Description..: Determine the suffix, as spoken, for a given integer with
 *                 minimal validation.
 */
using System;

namespace Beam.Example.EndsWell
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            int num1;
            string ext1;

            // user input - Minimal Input Validation
            Console.WriteLine();
            Console.WriteLine(" Input an integer from 1 thru 10");

            Console.WriteLine();
            Console.Write(" Enter Number ........: ");
            num1 = Convert.ToInt16(Console.ReadLine());

            // logic for integers 1, 2 || 3
            if (num1 == 1)
            {
               ext1 = "st";

            }
            else if (num1 == 2)
            {
               ext1 = "nd";

            }
            else if (num1 == 3)
            {
               ext1 = "rd";
            }
            else
            {
               ext1 = "th"; // if not 1, 2 || 3, add "th"
            }

            // logic for integer <= 0 || > 10
            if (num1 <= 0 || num1 > 10)
            {
               Console.WriteLine();
               Console.Write(" [ {0} ] is not an integer from 1 thru 10.\n\n", num1);

            }
            else
            {
               // print results
               Console.Write(" Integer With Ending ..: {0}{1}\n", num1, ext1);
               Console.WriteLine();

            }
            Console.Write(" Press Any Key to Exit...");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.EndsWell
