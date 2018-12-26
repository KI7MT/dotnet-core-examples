/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.2 AccountBalancer.dll
 *  Description..: While loop Account Balancer
 */
using System;

namespace Beam.Example.Introductory.AccountBalancer
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double numControl = 0;
            double serviceFee = 0;
            double bounceFee = 10;
            double firstRun = 0;
            double accBalance = 0;
            double input;

            // print header
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(" Account Balancer");
            Console.WriteLine("  * To Credit account, use a positive integer ..: 100");
            Console.WriteLine("  * To Debit account, use a negative integer....: -100");
            Console.WriteLine("  * To view account balance, use ...............: 8888");
            Console.WriteLine("  * To print end-of-month summary use ..........: 9999");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();

            // start loop
            while (numControl != 9999)
            {
                // If first run = 0, present initial balance message, add to accBalance and increment firstRun counter
                if (firstRun == 0)
                {
                    Console.Write("  Enter Initial Bank Balance ...: ");
                    input = Convert.ToInt16(Console.ReadLine());
                    accBalance = +input;
                    firstRun++;
                }
                else // If not first run, do everything else
                {
                    Console.Write("  Enter credit or debit value ..: ");
                    input = Convert.ToDouble(Console.ReadLine());

                    // Do not add 8888 | 9999 as input values to accBalance
                    if (input == 8888 | input == 9999)
                    {
                        accBalance = (accBalance + 0);
                    }
                    else
                    {
                        if ((input < 0) && (accBalance + input) < 0) // Cover the debit + a bounce fee
                        {
                            accBalance = accBalance - bounceFee;  // Bounce Fee due to lack of funds
                            accBalance = accBalance + input; // Also reduce the accBalance by the amount of the check / debit
                        }
                        else
                        {
                            accBalance = accBalance + input;
                        }
                    }
                }

                // Process user input: 8888 ~ current balance
                if (input == 8888)
                {
                    Console.WriteLine("  Current account balance ......: {0:c}", accBalance);
                    Console.WriteLine();
                }

                // Process user input of: 9999 ~ End of Month Statement
                if (input == 9999)
                {
                    if ((accBalance * 0.10) < 10) // Use 10% of balance if < $10.00 otherwise, use $10.00 for Service Fee
                    {
                        serviceFee = (accBalance * 0.10);
                    }
                    else
                    {
                        serviceFee = 10;
                    }

                    // Apply service fee
                    if (accBalance < 0)
                    {
                        accBalance = (accBalance + serviceFee);
                    }
                    else
                    {
                        accBalance = (accBalance - serviceFee);
                    }

                    // print results
                    Console.WriteLine();
                    Console.WriteLine("  End of Month Summary");
                    Console.WriteLine("  Monthly Service Fee ..........: {0:c}", serviceFee);
                    Console.WriteLine("  End of Month Balance .........: {0:c}", accBalance);
                    Console.WriteLine();
                    numControl = 9999;
                }
            }
            // end while loop

            // print footer
            Console.WriteLine();

        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.Introductory.AccountBalancer