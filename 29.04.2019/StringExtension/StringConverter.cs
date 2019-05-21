using System;
using System.Text;

namespace StringExtension
{
    /// <summary>
    /// Converted string.
    /// </summary>
    public class StringConverter
    {
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">source is null</exception>
        /// <exception cref="ArgumentException">source contains only white spaces</exception>
        /// <exception cref="ArgumentOutOfRangeException">count less then 0</exception>
        public string Convert(string source, int count)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)}");
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("source contains only white spaces");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(count)}");
            }

            var sourceTemp = source;
            var iterationCount = count;

            while (count > 0)
            {
                var strBuilder = new StringBuilder(sourceTemp.Length);

                for (int i = 0; i < sourceTemp.Length; i += 2)
                {
                    strBuilder.Append(sourceTemp[i]);
                }

                for (int i = 1; i < sourceTemp.Length; i += 2)
                {
                    strBuilder.Append(sourceTemp[i]);
                }

                sourceTemp = strBuilder.ToString();

                count--;

                if (sourceTemp == source)
                {
                    count = iterationCount % (iterationCount - count);
                }
            }

            return sourceTemp;
        }
    }
}