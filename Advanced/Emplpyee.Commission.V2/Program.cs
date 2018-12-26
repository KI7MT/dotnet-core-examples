/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Advanced
 *  Target ......: netcoreapp2.0 Employee.Commission.V2.dll
 *  Description..: Calculate commission for one or more employee's
 *                 Uses: Struct, Array of Struct, If, If-Else, for-loop
 *                       foreach-loop, and methods
 */
using System;

namespace TicTacToe
{
    class Program
    {
        #region Struct: employeeRecord 

        struct employeeRecord
        {
            public String empName;
            public String empId;
            public String empClass;
            public double empHoursWorked;
            public double empHourlyRate;
            public double empBaseHours;
            public double empBaseWage;
            public double empOvertimeHours;
            public double empOvertimeRate;
            public double empOvertimeWage;
            public double empWage;
            public double empSalesAmount;
            public double empComRate;
            public double empComAmount;
            public double empGrossPay;
            public int empError1;
            public int empError2;
        }

        #endregion

        #region Main Method

        static void Main(string[] args)
        {
            Console.Title = "Intermediate Employee Commission Calculator";

            // clear screen
            Console.Clear();

            // number of personnel to process
            int numPersonnel = 0;

            // method variables
            double fiveZero = 0.050; 
            double fiveFive = 0.055;
            double sixFive = 0.065;
            double sevenFive = 0.075;
            double nineZero = 0.090;
            double hourly1 = 14.50;
            double hourly2 = 20.25;
            double hourly3 = 16.50;
            double hourly4 = 19.75;
            double baseHours = 40.0;
            double overTimeRate = 1.5;

            // error messages
            string error1 = "Sales Class Error, no commission paid.";
            string error2 = "Sales Class Error, no wages paid.";

            // accumulated totals
            double totalCommission = 0;
            double totalHourlyWages = 0;
            double totalPayroll = 0;

            // Method: print header
            printHeader();

            // set number of personnel to process (array of struct)
            Console.Write(" Number of personnel ....: ");
            numPersonnel = Convert.ToInt16(Console.ReadLine());
            employeeRecord[] allRecords = new employeeRecord[numPersonnel];

            // start - employee main loop
            for (int pCount = 0; pCount < numPersonnel; pCount++)
            {
                // initialize new employee record ( employee main loop )
                allRecords[pCount] = new employeeRecord();

                // enter values into record array ( employee main loop )
                Console.WriteLine();
                Console.Write(" Salespersons's Name ....: ");
                allRecords[pCount].empName = Console.ReadLine();

                Console.Write(" Salespersons's Number ..: ");
                allRecords[pCount].empId = Console.ReadLine();

                Console.Write(" Hours Worked ...........: ");
                allRecords[pCount].empHoursWorked = Convert.ToDouble(Console.ReadLine());

                Console.Write(" Sales Amount ...........: ");
                allRecords[pCount].empSalesAmount = Convert.ToDouble(Console.ReadLine());

                Console.Write(" Sales Class ............: ");
                allRecords[pCount].empClass = Console.ReadLine();

                // begin - commission and hourly rates calculations ( employee main loop )
                if (allRecords[pCount].empClass == "1" | allRecords[pCount].empClass == "2" | allRecords[pCount].empClass == "3" | allRecords[pCount].empClass == "4")
                {
                    // set initial values for error1/2
                    allRecords[pCount].empError1 = 0;
                    allRecords[pCount].empError2 = 0;

                    if (allRecords[pCount].empClass == "1") // CLass-1 hourly rate, all = $14.50
                    {
                        allRecords[pCount].empHourlyRate = hourly1;

                        if (allRecords[pCount].empSalesAmount <= 2500)
                        {
                            allRecords[pCount].empComRate = fiveZero; // 5.0 %
                        }
                        else if (allRecords[pCount].empSalesAmount > 2500 & allRecords[pCount].empSalesAmount < 4500)
                        {
                            allRecords[pCount].empComRate = sixFive; // 6.5%
                        }
                        else
                        {
                            allRecords[pCount].empComRate = nineZero; // 9.0%
                        }
                    }
                    else if (allRecords[pCount].empClass == "2") // Class-2 hourly rate, all = $20.25
                    {
                        allRecords[pCount].empHourlyRate = hourly2;

                        if (allRecords[pCount].empSalesAmount <= 2500)
                        {
                            allRecords[pCount].empComRate = fiveFive; // 5.5%
                        }
                        else
                        {
                            allRecords[pCount].empComRate = sixFive;
                        }
                    }
                    else if (allRecords[pCount].empClass == "3") // Class-3 hourly rate, all = $16.50
                    {
                        allRecords[pCount].empHourlyRate = hourly3;
                        allRecords[pCount].empComRate = sevenFive; // 7.5%
                    }
                    else if (allRecords[pCount].empClass == "4") // Class-4 hourly rate, all = $19.75
                    {
                        allRecords[pCount].empHourlyRate = hourly4;
                        allRecords[pCount].empComRate = nineZero; // 9.0%
                    }
                }
                else
                {
                    // set hourly and commission rate to 0 for unknown sales class
                    // set error1/2 status for unknown sales class
                    allRecords[pCount].empError1 = 1;
                    allRecords[pCount].empError2 = 1;
                    allRecords[pCount].empHourlyRate = 0;
                    allRecords[pCount].empComRate = 0;
                }

                // determine employee and total commission ( employee main loop )
                if (allRecords[pCount].empError1 == 0)
                {
                    totalCommission = totalCommission + (allRecords[pCount].empComRate * allRecords[pCount].empSalesAmount);
                    allRecords[pCount].empComAmount = allRecords[pCount].empComRate * allRecords[pCount].empSalesAmount;
                }

                // determine hourly wages ( employee main loop )
                if (allRecords[pCount].empError2 == 0)
                {
                    // calculate overtime rate & wage + standard rate & time
                    if (allRecords[pCount].empHoursWorked > 40)
                    {
                        allRecords[pCount].empOvertimeHours = allRecords[pCount].empHoursWorked - baseHours;
                        allRecords[pCount].empOvertimeRate = allRecords[pCount].empHourlyRate * overTimeRate;
                        allRecords[pCount].empOvertimeWage = allRecords[pCount].empOvertimeHours * allRecords[pCount].empOvertimeRate;
                        allRecords[pCount].empBaseHours = allRecords[pCount].empHoursWorked - allRecords[pCount].empOvertimeHours;
                        allRecords[pCount].empBaseWage = allRecords[pCount].empBaseHours * allRecords[pCount].empHourlyRate;
                        allRecords[pCount].empWage = allRecords[pCount].empBaseWage + allRecords[pCount].empOvertimeWage;
                    }
                    else
                    {
                        // if no overtime, just use base rates and hours worked
                        allRecords[pCount].empWage = allRecords[pCount].empHoursWorked * allRecords[pCount].empHourlyRate;
                    }

                    // add wages to totalHourlyWages
                    totalHourlyWages = totalHourlyWages + allRecords[pCount].empWage;
                }

                // sum up employee GrossPay ( employee main loop )
                if (allRecords[pCount].empError2 == 0)
                {
                    allRecords[pCount].empGrossPay = allRecords[pCount].empWage + allRecords[pCount].empComAmount;
                }
            }
            // end - employee main loop

            // print header - grand totals for all employee's
            totalPayroll = totalCommission + totalHourlyWages;
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine(" Total Commission .......: {0:c}", totalCommission);
            Console.WriteLine(" Total Hourly Wages  ....: {0:c}", totalHourlyWages);
            Console.WriteLine(" Total Gross Pay ........: {0:c}", totalPayroll);
            Console.WriteLine("****************************************");

            // start loop - employee summary
            foreach (employeeRecord thisRecord in allRecords)
            {
                // employee summary
                Console.WriteLine();
                Console.WriteLine(" {0} Summary", thisRecord.empName);
                Console.WriteLine(" Salesperson's ID .......: {0:c}", thisRecord.empId);

                // conditional print if Sales Class is != ( 1,2,3,4 )
                if (thisRecord.empError1 != 0 | thisRecord.empError2 != 0)
                {
                    // print employee summary error messages
                    Console.WriteLine(" Total Wage .............: {0}", error2);
                    Console.WriteLine(" Commission .............: {0}", error1);
                    Console.WriteLine(" Gross Pay...............: {0}", error2);
                }
                else
                {
                    // print employee summary messages
                    Console.WriteLine(" Total Wage .............: {0:c}", thisRecord.empWage);
                    Console.WriteLine(" Commission .............: {0:c}", thisRecord.empComAmount);
                    Console.WriteLine(" Gross Pay...............: {0:c}", thisRecord.empGrossPay);
                }
            }
            // end loop - employee summary

            // Method: print footer
            printFooter();

        }

        #endregion

        #region Main Header

        static void printHeader()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(" Sales Commission Calculator");
            Console.WriteLine("  1. Enter the number of salespersons's to process");
            Console.WriteLine("  2. For each salesperson, enter the following: ");
            Console.WriteLine("     a) Salesperson's Name");
            Console.WriteLine("     b) Salesperson's Number");
            Console.WriteLine("     c) Hours Worked");
            Console.WriteLine("     d) Sales Amount, decimals are OK");
            Console.WriteLine("     e) Sales Class ( 1, 2, 3 or 4 )");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }

        #endregion

        #region Main Footer

        static void printFooter()
        {
            Console.WriteLine();
            Console.WriteLine(" Press Any Key to Exit...");
            Console.ReadKey();
        }

        #endregion

    } // END - class Program

} // END - namespace Beam.Example.Advanced.Employee.Commission