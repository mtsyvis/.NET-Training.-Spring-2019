using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._07
{
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
    }  
}
