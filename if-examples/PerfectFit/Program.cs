/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Description..: Determine various apsects of Squares and Rectangles
 *                 
 */
using System;

namespace Beam.Example.PerfectFit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Area of a rectangle  : a = RW *  RH
            // Area of a square     : a = SS * SS

            double rWidth;          // RW - rectangle width
            double rHeight;         // RH - rectangle height
            double sSide;           // SS - square side
            double sArea;           // Area of the square
            double rArea;           // Area of the rectangle

            // message strings
            string greatestArea;    // Which has the greatest area, rectangle or square
            string whoFits;         // Which object fits inside

            // Area result messages
            string greatestAreaSquare = "The object with the greatest area is the square.";
            string greatestAreaRectangle = "The object with the greatest area is the rectangle.";
            string sameArea = "The square and rectangle have the same area.";

            // Object fit messages
            string squareInsideRectangle = "The square fits inside the rectangle.";
            string rectangleInsideSquare = "The rectangle fits inside the square.";
            string neitherFit = "Neither fits inside the other.";

            // user input - No Input Validation
            Console.WriteLine();
            Console.WriteLine(" Enter values for the rectangle and square\n");

            Console.Write(" Enter Rectangle Width (RW) ...: ");
            rWidth = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter Rectangle Height (RH) ..: ");
            rHeight = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter Square Side (SS) .......: ");
            sSide = Convert.ToDouble(Console.ReadLine());


            // calculations - compute area for both the rectangle and square
            rArea = rWidth * rHeight;
            sArea = sSide * sSide;

            // logic to determine first message (who has the largest area)
            if (sArea > rArea)
            {
                greatestArea = greatestAreaSquare;
            }
            else if (sArea < rArea)
            {
                greatestArea = greatestAreaRectangle;
            }
            else
            {
                greatestArea = sameArea;
            }

            // logic to determine second message (who fits inside the other)
            if ((sSide < rWidth) & (sSide < rHeight))
            {
                whoFits = squareInsideRectangle;
            }
            else if ((rWidth < sSide) & (rHeight < sSide))
            {
                whoFits = rectangleInsideSquare;
            }
            else
            {
                whoFits = neitherFit;
            }

            // print results
            Console.WriteLine();
            Console.WriteLine(" {0}", greatestArea);
            Console.WriteLine(" {0}\n", whoFits);
            Console.Write(" Press Any Key to Exit...");
            Console.ReadKey();

        } // END - Main Method

    } // END - class Program

} // END - namespace Beam.Example.PerfectFit
