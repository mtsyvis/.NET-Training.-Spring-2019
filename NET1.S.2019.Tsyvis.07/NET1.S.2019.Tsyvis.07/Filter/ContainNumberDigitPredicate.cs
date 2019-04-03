using System;

namespace NET1.S._2019.Tsyvis._07.Filter
{
    /// <summary>
    /// Implement <see cref="IPredicateNumber"/>.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._07.IPredicateNumber" />
    public class ContainNumberDigitPredicate : IPredicateNumber
    {
        /// <summary>
        /// The digit to check condition.
        /// </summary>
        private readonly int digit;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainNumberDigitPredicate"/> class.
        /// </summary>
        /// <param name="digit">The digit.</param>
        /// <exception cref="ArgumentOutOfRangeException">digit is less then 0 or more then 9</exception>
        public ContainNumberDigitPredicate(int digit)
        {
            if (digit > 9 || digit < 0)
            {
                throw new ArgumentOutOfRangeException($"digit is less then 0 or more then 9 {nameof(digit)}");
            }

            this.digit = digit;
        }

        /// <summary>
        /// Determines whether the <paramref name="number"/> is contain the <see cref="digit"/>.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>true if the condition is met; otherwise false</returns>
        public bool Condition(int number)
        {
            number = Math.Abs(number);

            while (number > 0)
            {
                if (number % 10 == this.digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
