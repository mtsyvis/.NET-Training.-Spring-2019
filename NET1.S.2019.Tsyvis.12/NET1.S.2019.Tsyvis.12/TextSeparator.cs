using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._12
{
    /// <summary>
    /// Provide separating text.
    /// </summary>
    public static class TextSeparator
    {
        /// <summary>
        /// Gets the distinct word.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Distinct word</returns>
        /// <exception cref="ArgumentNullException">text is null</exception>
        public static IEnumerable<string> GetDistinctWordCaseInsensitive(string text)
        {
            if (text is null)
            {
                throw new ArgumentNullException($"text is null");
            }

            var words = GetWords(text);

            return DistinctWordsIterator(words, new WordEqualityComparer());
        }

        /// <summary>
        /// Gets the distinct words and count.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Distinct words and count</returns>
        public static IEnumerable<Word> GetDistinctWordsAndCount(string text)
        {
            var distinctWords = DistinctWordsIterator(GetWords(text), EqualityComparer<string>.Default);

            return GetDistinctWordsAndCountIterator(distinctWords, GetWords(text));
        }

        private static IEnumerable<Word> GetDistinctWordsAndCountIterator(IEnumerable<string> distinctWords, IEnumerable<string> allWords)
        {
            foreach (var distinctWord in distinctWords)
            {
                int count = 0;
                foreach (var word in allWords)
                {
                    if (distinctWord == word)
                    {
                        count++;
                    }
                }

                yield return new Word { Value = distinctWord, Count = count };
            }
        }

        private static IEnumerable<string> DistinctWordsIterator(IEnumerable<string> words, IEqualityComparer<string> comparer)
        {
            var set = new HashSet<string>(comparer);

            foreach (var word in words)
            {
                if (set.Add(word))
                {
                    yield return word;
                }
            }
        }

        private static IEnumerable<string> GetWords(string text)
        {
            return text.Split(new[] { ' ', ',', ':', '?', '!', '.', '[', ']', '>', '<' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
