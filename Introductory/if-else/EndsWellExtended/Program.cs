/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.2 EndsWellExtended.dll
 *  Description..: Determine the suffix, as spoken, for a given integer with
 *                 minimal validation. Valid for integers 1 thru 1000.
 *                 
 */
using System;

namespace Beam.Example.Introductory.EndsWellExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double num1;
            double mod100;
            double mod10;
            string ext1 = "";

            // user input - Minimal Validation
            Console.WriteLine();
            Console.WriteLine(" Enter a number between 1 and 1000");
            Console.WriteLine(" Decimal values are rounded to nearest whole number\n");

            Console.Write(" Enter Number ........: ");
            num1 = Convert.ToDouble(Console.ReadLine());

            // calculations
            num1 = Math.Round(num1, 0);
            mod100 = num1 % 100;
            mod10 = num1 % 10;

            // logic to determine integer ending
            if ((mod100 > 10) & (mod100 < 14) || (mod10 == 0) || (mod10 > 3))  // Find "th" first
            {
                ext1 = "th";
            }
            else // remaining integer endings
            {
                if (mod10 == 1)
                {
                    ext1 = "st";
                }
                if (mod10 == 2)
                {
                    ext1 = "nd";
                }
                if (mod10 == 3)
                {
                    ext1 = "rd";
                }
            }
            if ((num1 <= 0) || (num1 > 1000))  // throw simple exception
            {
                Console.WriteLine();
                Console.WriteLine(" [ {0} ] is not a number between 1 and 1000, please re-enter\n", num1);
            }
            else  // print results
            {
                Console.WriteLine(" Number With Ending ..: {0}{1}\n", num1, ext1);
            }

        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.Introductory.EndsWellExtended
