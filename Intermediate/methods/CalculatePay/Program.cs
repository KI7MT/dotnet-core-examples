/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 CalculatePay.dll
 *  Description..: Uses a method outside of Main to perform a calculation
 */
using System;

namespace Beam.Example.Intermediate.CalculatePay
{
    class Program
    {

        #region Main Method

        static void Main(string[] args)
        {
            // console title
            Console.Title = "Calculate Pay";

            // clear screen
            Console.Clear();

            // method variables
            double inputHoursWorked;
            double inputPayRate;
            double overtimeRate;
            double overtimeFactor = 1.5;
            double returnTotalPay;

            // Display program header
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" Calculate Total Pay");
            Console.WriteLine("  1. Enter Hours Worked");
            Console.WriteLine("  2. Enter Pay Rate");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();

            // user input - hours
            Console.Write(" Input Hours Worked ..: ");
            inputHoursWorked = Convert.ToDouble(Console.ReadLine());

            // user input - pay rate
            Console.Write(" Input Pay Rate ......: ");
            inputPayRate = Convert.ToDouble(Console.ReadLine());

            // calculation - overtime
            overtimeRate = inputPayRate * overtimeFactor;
            
            // calculation - pay by calling method
            returnTotalPay = CalcPay(inputHoursWorked, inputPayRate, overtimeRate);
            Console.WriteLine(" Total Pay ...........: {0:c}", returnTotalPay);

            // print footer
            Console.WriteLine();
        }

        #endregion

        #region Method: CalcPay
        
        static double CalcPay(double valueHoursWorked, double valuePayRate, double valueOvertimeRate)
        {
            double valueBasePay = 0;
            double valueOvertimePay = 0;

            // Calculate total Base Pay including Overtime for Hours > 40
            if (valueHoursWorked > 40)
            {
                valueBasePay = 40 * valuePayRate;
                valueOvertimePay = (valueHoursWorked - 40) * valueOvertimeRate;
            }
            else
            {
                // If hours =< 40, only calculate Base Pay
                valueBasePay = valueHoursWorked * valuePayRate;
            }

            return valueBasePay + valueOvertimePay;
        }

        #endregion

    } // end class Program

} // end namespace Beam.Example.Intermediate.CalculatePay