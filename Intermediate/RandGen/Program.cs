using System;
using System.Linq;

namespace RandGen
{
    /// <summary>
    /// Randome number, letter, symbol, combination generator
    /// Credit: https://rosettacode.org/wiki/Password_generator#C.23
    /// Packaged by: Greg Beam, KI7MT 
    /// </summary>
    public class Program
    {
        const string Lower = "abcdefghijklmnopqrstuvwxyz";
        const string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string Digits = "0123456789";
        const string Symbols = "!\"#$%&'()*+,-./:;<=>?@[]^_{|}~";
        static readonly string[] Full = { Lower, Upper, Digits, Symbols };
        const string Similar = "Il1O05S2Z";
        static readonly string[] Excluded = Full.Select(x => new string(x.Except(Similar).ToArray())).ToArray();

        static Random _rng = new Random();
        static string[] _symbolSet = Full;

        /// <summary>
        /// Main method to generates number-letter-symbol combinations
        /// </summary>
        /// <param name="args">-l:x -c:x -s:x -x:x</param>
        static void Main(string[] args)
        {
            int length = 12, count = 1;
            try
            {
                foreach (var x in args.Select(arg => arg.Split(':')))
                {
                    switch (x[0])
                    {
                        case "-l": length = int.Parse(x[1]); break;
                        case "-c": count = int.Parse(x[1]); break;
                        case "-s": _rng = new Random(x[1].GetHashCode()); break;
                        case "-x": _symbolSet = bool.Parse(x[1]) ? Excluded : Full; break;
                        default: throw new FormatException("Could not parse arguments");
                    }
                }
            }
            catch { ShowUsage(); return; }
            try
            {
                for (int i = 0; i < count; i++)
                    Console.WriteLine(GenerateWord(length));
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        } // end main method

        /// <summary>
        /// Show usage message
        /// </summary>
        static void ShowUsage()
        {
            Console.WriteLine("\nUsage: RanGen [-l:length] [-c:count] [-s:seed] [-x:(true|false)]\n");
            Console.WriteLine("\t-l: the length of the generated combinations");
            Console.WriteLine("\t-c: the number of generated combinations");
            Console.WriteLine("\t-s: seed for the random number generator");
            Console.WriteLine("\t-x: exclude similar characters: " + Similar);
            Console.WriteLine("\nExample: RanGen -l:10 -c:5 -s:\"Sample Seed\" -x:true\n");
        } // end show usage

        /// <summary>
        /// Method to generate string combinations
        /// </summary>
        /// <param name="length">length of string to be generated</param>
        /// <returns></returns>
        static string GenerateWord(int length)
        {
            var minLength = _symbolSet.Length - 1;
            if (length < minLength)
                throw new Exception("Combination length must be " + minLength + " or greater");

            int[] usesRemaining = Enumerable.Repeat(1, _symbolSet.Length).ToArray();
            usesRemaining[minLength] = length - minLength;
            var genword = new char[length];
            for (int ii = 0; ii < length; ii++)
            {
                int set = _rng.Next(0, _symbolSet.Length);
                if (usesRemaining[set] > 0)
                { 
                    usesRemaining[set]--;
                    genword[ii] = _symbolSet[set][_rng.Next(0, _symbolSet[set].Length)];
                }
                else ii--;
            }
            return new string(genword);
        } // end GenerateWord

    } // end class Program

} // end - namespace RandGen
