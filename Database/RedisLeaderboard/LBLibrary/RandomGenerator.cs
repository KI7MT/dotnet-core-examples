using System;
using System.Linq;

namespace LBLibrary
{
    public class RandomGenerator
    {
        #region TypeString: returns string + integers

        /// <summary>
        /// Random number, letter combination generator
        /// Credit: https://rosettacode.org/wiki/Password_generator#C.23
        /// Adapted for purpose: Greg Beam
        /// </summary>
        /// <param name="length">Number of digits in the final string</param>
        /// <returns>String combination</returns>
        public static string TypeString(int length)
        {
            string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string Digits = "0123456789";
            string[] Full = { Upper, Digits };
            Random ranN = new Random();
            string[] charS = Full;

            var minLength = charS.Length - 1;
            if (length < minLength)
                throw new Exception("Combination length must be " + minLength + " or greater");

            int[] usesRemaining = Enumerable.Repeat(1, charS.Length).ToArray();
            usesRemaining[minLength] = length - minLength;
            var genword = new char[length];

            for (int ii = 0; ii < length; ii++)
            {
                int set = ranN.Next(0, charS.Length);
                if (usesRemaining[set] > 0)
                {
                    usesRemaining[set]--;
                    genword[ii] = charS[set][ranN.Next(0, charS[set].Length)];
                }
                else ii--;
            }
            return new string(genword);
        }

        #endregion

        #region TypeDouble: returns double

        /// <summary>
        /// Generate a random number with x precision
        /// </summary>
        /// <param name="lower">lower limit</param>
        /// <param name="upper">upper limit</param>
        /// <param name="precision">decimal places</param>
        /// <returns>double with decimal</returns>
        public double TypeDouble(int lower, int upper, int precision)
        {
            Random ranN = new Random();
            double _double = Convert.ToDouble(ranN.Next(lower, upper));
            return Math.Round(_double, precision);
        }

        #endregion

        #region TypeInteger: retruns integer

        /// <summary>
        /// Random number generator (integer)
        /// </summary>
        /// <param name="lower">lower range</param>
        /// <param name="upper">upper range</param>
        /// <returns>integer</returns>
        public int TypeInteger(int lower, int upper)
        {
            Random ranN = new Random();
            return Convert.ToInt32(ranN.Next(lower, upper));
        }

        #endregion

    } // end class RandomGenerator

} // end namespace LBLibrary