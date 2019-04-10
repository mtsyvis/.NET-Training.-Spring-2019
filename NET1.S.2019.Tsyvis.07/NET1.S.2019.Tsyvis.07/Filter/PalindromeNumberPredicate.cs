namespace NET1.S._2019.Tsyvis._07.Filter
{
    /// <summary>
    /// Implement <see cref="IPredicateNumber"/>.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._07.IPredicateNumber" />
    public class PalindromeNumberPredicate<T> : IPredicateNumber<T>
    {
        /// <summary>
        /// Determines whether the <paramref name="number"/> is palindrome.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>true if the condition is met; otherwise false</returns>
        public bool Condition(T number)
        {
            var s = number.ToString();

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
