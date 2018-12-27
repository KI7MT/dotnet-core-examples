/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.2 SaintIves.dll
 *  Description..: Simple compounding math statements
 *  
 *  Solve the Riddle: As I was going to St. Ives, I met a man with seven wives.
 *                    Every wife had seven sacks, every sack had seven cats,
 *                    every cat had seven kittens. Kittens, cats, sacks, and
 *                    wives, how many were going to St. Ives?
 */
using System;

namespace Beam.Example.Introductory.SaintIves
{
    class Program
    {
        static void Main(string[] args)
        {
            // riddle variables / calculations
            int nMan = 1;
            int nWives = 7;
            int nSacks = nWives * 7;
            int nCats = nSacks * 7;
            int nKittens = nCats * 7;
            int nTotal = nMan + nWives + nSacks + nCats + nKittens;

            // the puzzle
            Console.WriteLine("\n As I was going to St. Ives, I met a man with seven wives.");
            Console.WriteLine(" Every wife had seven sacks. Every sack had seven cats.");
            Console.WriteLine(" Every cat had seven kittens. Kittens, cats, sacks, and");
            Console.WriteLine(" wives, how many were going to St. Ives?\n");

            // the answer
            Console.WriteLine(" Man ......: {0}", nMan);
            Console.WriteLine(" Wives ....: {0}", nWives);
            Console.WriteLine(" Sacks ....: {0}", nSacks);
            Console.WriteLine(" Cats .....: {0}", nCats);
            Console.WriteLine(" Kittens ..: {0}", nKittens);
            Console.WriteLine(" Total ....: {0}", nTotal);
            Console.WriteLine();

        } // end Main Method

    } // end class Program

} // end namespace Beam.Example.Introductory.SaintIves
