using System;
using System.Collections.Generic;
using System.Text;

namespace NET1.S._2019.Tsyvis._04
{
    /// <summary>
    /// Provides data transformation
    /// </summary>
    public class Transformer
    {
        private readonly Dictionary<char, string> SymbolsOfRealNumber = new Dictionary<char, string>()
        {
            {'0', "zero" },
            {'1', "one" },
            {'2', "two" },
            {'3', "three" },
            {'4', "four" },
            {'5', "five" },
            {'6', "six" },
            {'7', "seven" },
            {'8', "eight" },
            {'9', "nine" },
            {'-', "minus" },
            {'.', "point" }
        };

        /// <summary>
        /// Transform the real number to word.
        /// </summary>
        /// <param name="number">The number to transforming.</param>
        /// <returns>word</returns>
        public string TransformToWords(double number)
        {
            char[] symbols = number.ToString().ToCharArray();
            StringBuilder wordBilder = new StringBuilder();
            wordBilder.Append(SymbolsOfRealNumber[symbols[0]]);

            for(int i = 1; i < symbols.Length; i++)
            {
                string word = SymbolsOfRealNumber[symbols[i]];
                wordBilder.Append(" ");
                wordBilder.Append(word);
            }

            return  wordBilder.ToString();
        }
    }
}
