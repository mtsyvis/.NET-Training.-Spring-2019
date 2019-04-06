namespace NET1.S._2019.Tsyvis._08
{
    /// <summary>
    /// Provide finding gcd.
    /// </summary>
    public interface IGcdAlgorithm
    {
        /// <summary>
        /// Find gcd for 2 numbers.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>founded gcd</returns>
        int Calculate(int first, int second);
    }
}
