using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._07.Transform
{
    /// <summary>
    /// Realize numeral system.
    /// </summary>
    internal class NumeralSystem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumeralSystem"/> class.
        /// </summary>
        /// <param name="numeralSystem">The numeral system.</param>
        /// <exception cref="System.ArgumentException">numeral system is wrong. It must me more then 1 and less then 35</exception>
        public NumeralSystem(int numeralSystem)
        {
            if (numeralSystem > 35 || numeralSystem < 1)
            {
                throw new ArgumentException($"{nameof(numeralSystem)} is wrong. It must me more then 1 and less then 35");
            }

            this.NumberSystemBase = numeralSystem;
            this.NumberDictionary = new Dictionary<char, int>(numeralSystem);

            if (numeralSystem < 10)
            {
                this.SetDigitValuesNumber(numeralSystem);
            }
            else
            {
                this.SetDigitValuesNumber(10);
                this.SetLetterValuesNumber(numeralSystem);
            }
        }

        /// <summary>
        /// Gets the number system base.
        /// </summary>
        /// <value>
        /// The number system base.
        /// </value>
        public int NumberSystemBase { get; }

        /// <summary>
        /// Gets the number dictionary.
        /// </summary>
        /// <value>
        /// The number dictionary.
        /// </value>
        public Dictionary<char, int> NumberDictionary { get; private set; }

        private void SetDigitValuesNumber(int numeralSystem)
        {
            char key = '0';
            for (int i = 0; i < numeralSystem; i++)
            {
                this.NumberDictionary.Add(key, i);
                key++;
            }           
        }

        private void SetLetterValuesNumber(int numeralSystem)
        {
            char key = 'A';
            for (int i = 10; i < numeralSystem; i++)
            {
                this.NumberDictionary.Add(key, i);
                key++;
            }
        }
    }
}
