using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._07
{
    using NET1.S._2019.Tsyvis._07.Transform;

    /// <summary>
    /// Provide manipulation with array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Filters the array by selected <paramref name="predicate"/>.
        /// </summary>
        /// <param name="array">The array to filter.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>filtered array</returns>
        /// <exception cref="ArgumentNullException">predicate is null</exception>
        public static int[] Filter(this int[] array, IPredicateNumber predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException($"predicate is null{nameof(predicate)}");
            }

            var filteredNumbers = new List<int>();

            foreach (var i in array)
            {
                if (predicate.Condition(i))
                {
                    filteredNumbers.Add(i);
                }
            }

            return filteredNumbers.ToArray();
        }

        /// <summary>
        /// Transforms the array by selected rule.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="rule">The rule.</param>
        /// <returns>transformed array of strings</returns>
        /// <exception cref="ArgumentNullException">predicate is null</exception>
        public static string[] Transform(this double[] array, ITransformDoubleRule rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException($"predicate is null{nameof(rule)}");
            }

            var transformedNumbers = new List<string>();

            foreach (var i in array)
            {
                transformedNumbers.Add(rule.Transform(i));
            }

            return transformedNumbers.ToArray();
        }
    }  
}
