/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Description..: Calculate Sum, Difference, Quotient, Product, and Average
 */
using System;

namespace Beam.Example.BasicMath
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum;
            double secondNum;
            double sOut;
            double dOut;
            double qOut;
            double pOut;
            double aOut;

            Console.WriteLine();
            Console.Write(" Enter First Number ...: ");
            firstNum = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter Second Number ..: ");
            secondNum = Convert.ToDouble(Console.ReadLine());

            sOut = (firstNum + secondNum);
            dOut = Math.Abs(firstNum - secondNum);
            qOut = firstNum / secondNum;
            pOut = firstNum * secondNum;
            aOut = (firstNum + secondNum) / 2;

            Console.WriteLine();
            Console.WriteLine(" Sum ..................: {0}", sOut);
            Console.WriteLine(" Difference ...........: {0}", dOut);
            Console.WriteLine(" Quotient .............: {0}", qOut);
            Console.WriteLine(" Product ..............: {0}", pOut);
            Console.WriteLine(" Average ..............: {0}", aOut);
            Console.WriteLine();
            Console.Write(" Press Any Key To Exit...");
            Console.ReadKey();
        }
    }
}