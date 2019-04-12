using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._07.Transform
{
    /// <summary>
    /// Provide creating Russian dictionary.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._07.Transform.IDictionariesCreator" />
    public class RussianDictionaryCreator : IDictionariesCreator<double>
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
                           ['0'] = "ноль",
                           ['1'] = "один",
                           ['2'] = "два",
                           ['3'] = "три",
                           ['4'] = "четыре",
                           ['5'] = "пять",
                           ['6'] = "шесть",
                           ['7'] = "семь",
                           ['8'] = "восемь",
                           ['9'] = "девять",
                           ['.'] = "точка",
                           ['-'] = "минус"
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
                            [double.NaN] = "не число",
                            [double.Epsilon] = "эпсилон",
                            [double.NegativeInfinity] = "неопределенность",
                            [double.PositiveInfinity] = "неопределенность"
            };
        }
    }
}
