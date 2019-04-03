using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._07.Transform
{
    /// <summary>
    /// Provide creating English dictionary.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._07.Transform.IDictionariesCreator" />
    public class EnglishDictionaryCreator : IDictionariesCreator
    {
        /// <summary>
        /// Gets the words.
        /// </summary>
        /// <returns>
        /// dictionary with words
        /// </returns>
        public Dictionary<char, string> GetWords()
        {
            return new Dictionary<char, string>()
                       {
                           ['0'] = "zero",
                           ['1'] = "one",
                           ['2'] = "two",
                           ['3'] = "three",
                           ['4'] = "four",
                           ['5'] = "five",
                           ['6'] = "six",
                           ['7'] = "seven",
                           ['8'] = "eight",
                           ['9'] = "nine",
                           ['.'] = "point",
                           ['-'] = "minus"
            };
        }

        /// <summary>
        /// Gets the special doubles.
        /// </summary>
        /// <returns>
        /// dictionary with special doubles
        /// </returns>
        public Dictionary<double, string> GetSpecialDoubles()
        {
            return new Dictionary<double, string>()
                       {
                           [double.NaN] = "is not a number",
                           [double.Epsilon] = "epsilon",
                           [double.NegativeInfinity] = "negative infinity",
                           [double.PositiveInfinity] = "positive infinity"
            };
        }
    }
}
