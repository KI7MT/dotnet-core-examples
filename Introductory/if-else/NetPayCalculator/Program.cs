/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: net8.0 NetPayCalculator.dll
 *  Description..: Calculate Net Pay by taking out fixed tax rates
 */
using System;

namespace Beam.Example.Introductory.NetPayCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double hoursWorked;
            double hourlyRate;
            double fedTax;
            double stateTax;
            double ssTax;
            double grossPay;
            double netPay;

            // tax rates - update as needed
            double fedTaxRate = 0.20;
            double stateTaxRate = 0.05;
            double ssTaxRate = 0.062;

            // user input section - No Input Validation
            Console.WriteLine();
            Console.Write(" Hours Worked .............: ");
            hoursWorked = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Hourly Rate ..............: ");
            hourlyRate = Convert.ToDouble(Console.ReadLine());

            // calculations
            grossPay = hourlyRate * hoursWorked;
            fedTax = grossPay * fedTaxRate;
            stateTax = grossPay * stateTaxRate;
            ssTax = grossPay * ssTaxRate;
            netPay = (grossPay - (fedTax + stateTax + ssTax));

            // print results
            Console.WriteLine();
            Console.WriteLine(" Gross Pay . .............: {0:C}", grossPay);
            Console.WriteLine("   Federal Tax ...........: {0:C}", -fedTax);
            Console.WriteLine("   State Tax  ............: {0:C}", -stateTax);
            Console.WriteLine("   Social Security .......: {0:C}", -ssTax);
            Console.WriteLine(" Net Pay .................: {0:C}", netPay);
            Console.WriteLine();

        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.Introductory.NetPayCalculator