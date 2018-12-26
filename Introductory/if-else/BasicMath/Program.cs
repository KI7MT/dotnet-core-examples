/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.2 BasicMath.dll
 *  Description..: Calculate Sum, Difference, Quotient, Product, and Average
 */
using System;

namespace Beam.Example.Introductory.BasicMath
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double firstNum;
            double secondNum;
            double sOut;
            double dOut;
            double qOut;
            double pOut;
            double aOut;

            // user input - No Input Validation
            Console.WriteLine();
            Console.Write(" Enter First Number ...: ");
            firstNum = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter Second Number ..: ");
            secondNum = Convert.ToDouble(Console.ReadLine());

            // calculations
            sOut = (firstNum + secondNum);
            dOut = Math.Abs(firstNum - secondNum);
            qOut = firstNum / secondNum;
            pOut = firstNum * secondNum;
            aOut = (firstNum + secondNum) / 2;

            // print results
            Console.WriteLine();
            Console.WriteLine(" Sum ..................: {0}", sOut);
            Console.WriteLine(" Difference ...........: {0}", dOut);
            Console.WriteLine(" Quotient .............: {0}", qOut);
            Console.WriteLine(" Product ..............: {0}", pOut);
            Console.WriteLine(" Average ..............: {0}", aOut);
            Console.WriteLine();

        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.BasicMath