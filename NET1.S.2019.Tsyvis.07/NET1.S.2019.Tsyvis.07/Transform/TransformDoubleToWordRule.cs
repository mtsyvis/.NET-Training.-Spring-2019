using System;
using System.Collections.Generic;
using System.Text;

namespace NET1.S._2019.Tsyvis._07.Transform
{
    /// <summary>
    /// Provide transforming number to word representation.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._07.Transform.ITransform" />
    public class TransformDoubleToWordRule<TSource> : ITransform<string, TSource>
    {
        /// <summary>
        /// The creator of dictionary.
        /// </summary>
        private readonly IDictionariesCreator<TSource> creator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransformDoubleToWordRule"/> class.
        /// </summary>
        /// <param name="creator">The creator.</param>
        /// <exception cref="ArgumentNullException">creator is null</exception>
        public TransformDoubleToWordRule(IDictionariesCreator<TSource> creator)
        {
            this.creator = creator ?? throw new ArgumentNullException($"creator is null{nameof(creator)}");
        }

        /// <summary>
        /// Transforms the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// string representation of number
        /// </returns>
        public string Transform(TSource number)
        {
            Dictionary<TSource, string> specialCases = this.creator.GetSpecialDoubles();

            if (specialCases.TryGetValue(number, out string result))
            {
                return result;
            }

            Dictionary<char, string> words = this.creator.GetWords();

            return GetWordRepresentation(number, words);
        }

        /// <summary>
        /// Gets the word representation by dictionary.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>word representation</returns>
        private static string GetWordRepresentation(TSource number, Dictionary<char, string> dictionary)
        {
            char[] symbols = number.ToString().ToCharArray();
            var wordBuilder = new StringBuilder();
            foreach (var i in symbols)
            {
                wordBuilder.Append(dictionary[i]);
                wordBuilder.Append(" ");
            }

            return wordBuilder.ToString().TrimEnd();
        }
    }
}
