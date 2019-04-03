namespace NET1.S._2019.Tsyvis._07
{
    /// <summary>
    /// Checked condition of number.
    /// </summary>
    public interface IPredicateNumber
    {
        /// <summary>
        /// Conditions the specified <paramref name="number"/>.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>true if the condition is met; otherwise false</returns>
        bool Condition(int number);
    }
}
