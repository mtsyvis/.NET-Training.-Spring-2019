namespace NET1.S._2019.Tsyvis._07.Filter
{
    /// <summary>
    /// Implement <see cref="IPredicateNumber"/>.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._07.IPredicateNumber" />
    public class EvenNumberPredicate : IPredicateNumber<int>
    {
        /// <summary>
        /// Determines whether the <paramref name="number"/> is even.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>true if the condition is met; otherwise false</returns>
        public bool Condition(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
