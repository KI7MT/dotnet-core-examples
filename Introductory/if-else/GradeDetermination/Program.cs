/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.2 GradeDetermination.dll
 *  Description..: Determine letter grade from three input values
 */
using System;

namespace Beam.Example.Introductory.GradeDetermination
{
    class Program
    {
        static void Main(string[] args)
        {
            // method variables
            double score1;
            double score2;
            double score3;
            double aveScore;
            string letterGrade = "";

            // user input - No Input Validation
            Console.WriteLine();
            Console.WriteLine(" Enter three scores between 0 and 100\n");

            Console.Write(" Enter First Score ...: ");
            score1 = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter Second Score ..: ");
            score2 = Convert.ToDouble(Console.ReadLine());

            Console.Write(" Enter Third Score ...: ");
            score3 = Convert.ToDouble(Console.ReadLine());

            // calculation
            aveScore = (score1 + score2 + score3) / 3;

            // logic to determine letter grade based on aveScore
            if (aveScore >= 90)
            {
                letterGrade = "A";
            }
            else if ((aveScore >= 80) && (aveScore < 90))
            {
                letterGrade = "B";
            }
            else if ((aveScore >= 70) && (aveScore < 80))
            {
                letterGrade = "C";
            }
            else if ((aveScore >= 60) && (aveScore < 70))
            {
                letterGrade = "D";
            }
            else
            {
                letterGrade = "F";
            }

            // print results
            Console.WriteLine();
            Console.WriteLine(" Score Average .......: {0:#,#.000}", aveScore);
            Console.WriteLine(" Letter Grade ........: {0}\n", letterGrade);

         } // end Main Method

    } // end class Program

} // end Beam.Example.Introductory.GradeDetermination