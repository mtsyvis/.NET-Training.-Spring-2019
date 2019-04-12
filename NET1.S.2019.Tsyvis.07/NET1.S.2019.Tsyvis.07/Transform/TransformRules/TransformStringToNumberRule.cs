using System;
using System.Text.RegularExpressions;

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
        /// <param name="source"></param>
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
            if (!Regex.IsMatch(source, @"[a-zA-Z0-9]"))
            {
                throw new ArgumentException($"source have wrong symbols {nameof(source)}");
            }

            this.CheckStringForNumberSystem(source);

            source = source.ToUpper();
            int result = 0;

            for (int i = 0; i < source.Length; i++)
            {
                result += (int)Math.Pow(this.numeralSystem.NumberSystemBase, source.Length - i - 1)
                          * this.numeralSystem.NumberDictionary[source[i]];
            }

            return result;
        }

        private void CheckStringForNumberSystem(string source)
        {
            var iterator = this.numeralSystem.NumberDictionary.GetEnumerator();

            for (int i = 0; i < this.numeralSystem.NumberDictionary.Count; i++)
            {
                iterator.MoveNext();
            }

            char biggerSymbol = iterator.Current.Key;

            foreach (var symbol in source)
            {
                if (symbol > biggerSymbol)
                {
                    throw new ArgumentException($"Wrong string. String is not suitable for number system {nameof(source)} {nameof(this.numeralSystem.NumberSystemBase)}");
                }
            }
        }
    }
}
