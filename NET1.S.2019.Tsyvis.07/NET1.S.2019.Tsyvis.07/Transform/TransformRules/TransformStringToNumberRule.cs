using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._07.Transform.TransformRules
{
    /// <summary>
    /// Provide transforming string to a valid numeral system.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._07.Transform.ITransform{System.Int32, System.String}" />
    public class TransformStringToNumberRule : ITransform<int, string>
    {
        /// <summary>
        /// The numeral system
        /// </summary>
        private NumeralSystem numeralSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransformStringToNumberRule"/> class.
        /// </summary>
        /// <param name="numeralSystem">The numeral system.</param>
        /// <exception cref="System.ArgumentException">numeral system is wrong</exception>
        public TransformStringToNumberRule(int numeralSystem)
        {
            if (numeralSystem < 2 || numeralSystem > 16)
            {
                throw new ArgumentException($"{nameof(numeralSystem)} is wrong");
            }

            this.numeralSystem = new NumeralSystem(numeralSystem);
        }

        /// <summary>
        /// Transforms the specified number.
        /// </summary>
        /// <param name="source">the number</param>
        /// <returns>
        /// string representation
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="source"/> have wrong symbols
        /// or
        /// string is not suitable for number system
        /// </exception>
        public int Transform(string source)
        {
            source = source.ToUpper();
            int result = 0;
            try
            {
                int @base = 1;
                int startCalculation = @base * this.numeralSystem.NumberDictionary[source[source.Length - 1]];
                result = startCalculation;

                for (int i = source.Length - 2; i >= 0; i--)
                {
                    @base *= this.numeralSystem.NumberSystemBase;
                    result += @base * this.numeralSystem.NumberDictionary[source[i]];
                }
            }
            catch (KeyNotFoundException ex)
            {
                throw new ArgumentException($"Wrong string. String is not suitable for number system {nameof(source)} {nameof(this.numeralSystem.NumberSystemBase)}", ex);
            }

            return result;
        }
    }
}
