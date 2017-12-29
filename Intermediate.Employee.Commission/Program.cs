/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Intermediate
 *  Target ......: netcoreapp2.0 MLS.Listing.dll
 *  Description..: Calculate commission for one or more employee's
 *                 Uses only If, If-Else, and For loops
 */
using System;

namespace Intermediate.Employee.Commission
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            int numPersonnel = 0;

            double salesAmount;
            double cRate;
            double sCommission = 0;
            double totalCommission = 0;

            string salesName;
            string salesNumber;
            string salesClass;

            // commission rate variables
            double fiveZero = 0.050;               // 5.0%
            double fiveFive = 0.055;               // 5.5%
            double sixFive = 0.065;                // 6.5%
            double sevenZero = 0.070;              // 7.0%
            double eightZero = 0.080;              // 8.0%

            // print header
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(" Sales Commission Calculator");
            Console.WriteLine("  1. Enter the number of salespersons's to process");
            Console.WriteLine("  2. For each salesperson, enter the following: ");
            Console.WriteLine("     a) Salesperson's Name");
            Console.WriteLine("     b) Salesperson's Number");
            Console.WriteLine("     c) Sales Amount, decimals are OK");
            Console.WriteLine("     d) Sales Class - 1, 2, 3 or 4");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            // enter number of employees to process
            Console.Write(" Number of personnel ....: ");
            numPersonnel = Convert.ToInt16(Console.ReadLine());

            // start main loop
            for (int pCount = 0; pCount < numPersonnel; pCount++)
            {
                cRate = 0;

                // enter sales person information
                Console.WriteLine();
                Console.Write(" Salespersons's Name ....: ");
                salesName = Console.ReadLine();

                Console.Write(" Salespersons's Number ..: ");
                salesNumber = Console.ReadLine();

                Console.Write(" Sales Amount ...........: ");
                salesAmount = Convert.ToDouble(Console.ReadLine());

                Console.Write(" Sales Class ............: ");
                salesClass = Console.ReadLine();

                // calculate commission rate for each sales person by CLass
                if (salesClass == "1" | salesClass == "2" | salesClass == "3" | salesClass == "4")
                {
                    if (salesClass == "1")
                    {
                        if (salesAmount <= 1000)
                        {
                            cRate = fiveFive;
                        }
                        else if (salesAmount > 1000 & salesAmount < 2000)
                        {
                            cRate = sixFive;
                        }
                        else
                        {
                            cRate = eightZero;
                        }
                    }
                    else if (salesClass == "2")
                    
                    {
                        if (salesAmount <= 1000)
                        {
                            cRate = fiveZero;
                        }
                        else
                        {
                            cRate = sixFive;
                        }
                    }
                    else if (salesClass == "3")
                    {
                        cRate = fiveFive;
                    }
                    else if (salesClass == "4")
                    {
                        cRate = sevenZero;
                    }
                }
                else
                {
                    cRate = 0;
                }
                // end - commission rate calculation

                // print sales person summary
                Console.WriteLine();
                Console.WriteLine(" {0} Summary", salesName);
                Console.WriteLine(" Name ...................: {0}", salesName);
                Console.WriteLine(" Number .................: {0}", salesNumber);

                if (cRate > 0)
                {
                    sCommission = salesAmount * cRate;
                    totalCommission = totalCommission + sCommission;
                    Console.WriteLine(" Commission .............: {0:c}", sCommission);
                }
                else // warning of unknown commission Class
                {
                    Console.WriteLine(" Commission .............: Warning: unknown class, no commission paid.");
                }
            }
            // end main loop

            // print header - total commission for all sales persons
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(" Total Commission .......: {0:c}", totalCommission);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(" Press Any Key to Exit...");
            Console.ReadKey();
        
        } // END - Main Method

    } // END - class Program

} // END - namespace Intermediate.Employee.Commission