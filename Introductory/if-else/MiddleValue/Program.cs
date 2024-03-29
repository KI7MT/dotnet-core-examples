﻿/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: net8.0 MiddleValue.dll
 *  Description..: Determine the middle value of three integers
 */
using System;

namespace Beam.Example.Introductory.MiddleValue
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double num1;
            double num2;
            double num3;
            double middleNum;

            // user input - No Input Validation
            Console.WriteLine();
            Console.WriteLine(" Find the middle value of three numbers\n");

            Console.Write(" Enter first number ..: ");
            num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter second number ..: ");
            num2 = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter third number ...: ");
            num3 = Convert.ToDouble(Console.ReadLine());

            // logic to find the middle value.
            if ((num2 < num1 && num1 < num3) || (num3 < num1 && num1 < num2))
            {
                middleNum = num1;
            }
            else if ((num1 < num2 && num2 < num3) || (num3 < num2 && num2 < num1))
            {
                middleNum = num2;
            }
            else
            {
                middleNum = num3;
            }

            // print results
            Console.WriteLine();
            Console.WriteLine(" Middle Number is .....: {0}\n", middleNum);

        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.Introductory.MiddleValue
