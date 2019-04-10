using System;

namespace NET1.S._2019.Tsyvis._07.Filter
{
    /// <summary>
    /// Implement <see cref="IPredicateNumber`1"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="NET1.S._2019.Tsyvis._07.Filter.IPredicateNumber{T}" />
    public class ContainNumberDigitPredicate<T> : IPredicateNumber<T> 
    {
        /// <summary>
        /// The digit to check condition.
        /// </summary>
        private readonly char digit;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainNumberDigitPredicate{T}"/> class.
        /// </summary>
        /// <param name="digit">The digit.</param>
        /// <exception cref="ArgumentOutOfRangeException">digit is less then 0 or more then 9</exception>
        public ContainNumberDigitPredicate(char digit)
        {
            if (digit > '9' || digit < '0')
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
        public bool Condition(T number)
        {
            var strNumber = number.ToString().ToCharArray();

            for (int i = 0; i < strNumber.Length; i++)
            {
                if (strNumber[i] == this.digit)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
