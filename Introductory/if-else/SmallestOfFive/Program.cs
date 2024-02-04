/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: net8.0 SmallestOfFive.dll
 *  Description..: Determine the smallest of five numbers
 */
using System;

namespace Beam.Example.Introductory.SmallestOfFive
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double num1;
            double num2;
            double num3;
            double num4;
            double num5;
            double smallestNum;

            // user input - No Input Validation
            Console.WriteLine();
            Console.WriteLine(" Find the smallest of five numbers\n");

            Console.Write(" Enter first number ...: ");
            num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter second number ..: ");
            num2 = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter third number ...: ");
            num3 = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter fourth number ..: ");
            num4 = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter fifth number ...: ");
            num5 = Convert.ToDouble(Console.ReadLine());

            // logic to determine smallest number
            if (num1 <= num2 && num1 <= num3 && num1 <= num4 && num1 <= num5) // num1 is smallest
            {
               smallestNum = num1;
            }
            else if (num2 <= num1 && num2 <= num3 && num2 <= num4 && num2 <= num5) // num2 is smallest
            {
               smallestNum = num2;
            }
            else if (num3 <= num1 && num3 <= num2 && num3 <= num4 && num3 <= num5) // num3 is smallest
            {
               smallestNum = num3;
            }
            else if (num4 <= num1 && num4 <= num2 && num4 <= num3 && num4 <= num5) // num4 is smallest
            {
               smallestNum = num4;
            }
            else
            {
               smallestNum = num5; // if not num1 thru num4, smallest must be num5
            }

            // print results
            Console.WriteLine();
            Console.WriteLine(" Smallest number is ...: {0}\n", smallestNum);

        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.Introductory.SmallestOfFive
