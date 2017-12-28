/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 WhilePaymentPlan.dll
 *  Description..: While loop payment plan comparison, no user input
 */
using System;

namespace Beam.Example.WhilePaymentPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double plan1Rate = 100;
            double plan1Cash;
            double plan2Rate = 2;
            double plan2Cash;
            double counter = 1;

            // print header
            Console.WriteLine();
            Console.WriteLine(" Payment Plan Summary");
            Console.WriteLine();

            // start loop
            while (counter <= 10)
            {
                if (counter == 1) // Day 1 is a flat rate of pay for both plans
                {
                    plan1Cash = (plan1Rate * 1);
                    plan2Cash = (plan2Rate * 1);

                }
                else // day 1++ increases by $100.00 per day for Plan1, and Plan2 doubles each day starting at $2.00
                {
                    plan1Cash = (plan1Rate * counter);
                    plan2Cash = Math.Pow(plan2Rate, counter);

                }

                // print results
                Console.WriteLine(" Day {0} Results: Plan1 = {1:c} and Plan2 = {2:c}", counter, plan1Cash, plan2Cash);
                counter++;
            }
            // end loop

            // print footer
            Console.WriteLine();
            Console.WriteLine(" Press Any Key to Exit...");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.WhilePaymentPlan