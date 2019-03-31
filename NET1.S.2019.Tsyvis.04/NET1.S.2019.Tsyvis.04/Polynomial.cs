using System;

namespace NET1.S._2019.Tsyvis._04
{
    using System.Runtime.CompilerServices;
    using System.Text;

    /// <summary>
    /// Provide manipulation with polynomials.
    /// </summary>
    public sealed class Polynomial
    {
        /// <summary>
        /// The coefficients of polynomial.
        /// </summary>
        private readonly int[] coefficients;

        /// <summary>
        /// Initializes a new instance of the Polynomial.
        /// </summary>
        /// <param name="coefficients">The coefficients to initializing.</param>
        public Polynomial(params int[] coefficients)
        {
            this.coefficients = coefficients;
        }

        /// <summary>
        /// Adds polynomials using coefficients.
        /// </summary>
        /// <param name="a">The first polynomial to addition.</param>
        /// <param name="b">The second polynomial to addition.</param>
        /// <returns>result polynomial</returns>
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            int[] newCoeffients = AdditionArray(a.coefficients, b.coefficients);
            return new Polynomial(newCoeffients);
        }

        /// <summary>
        /// Subtracts polynomials using coefficients/
        /// </summary>
        /// <param name="a">The first polynomial to subtraction.</param>
        /// <param name="b">The second polynomial to subtraction.</param>
        /// <returns>result polynomial</returns>
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            int[] newCoeffientsRightOperand = MultiplicationByNumber(b.coefficients, -1);
            int[] newCoeffients = AdditionArray(a.coefficients, newCoeffientsRightOperand);
            return new Polynomial(newCoeffients);
        }

        /// <summary>
        /// Multiply polynomial by number.
        /// </summary>
        /// <param name="a">The polynomial to multiplication.</param>
        /// <param name="number">The number to multiplication.</param>
        /// <returns>result polynomial</returns>
        public static Polynomial operator *(Polynomial a, int number)
        {
            int[] newCoeffients = MultiplicationByNumber(a.coefficients, number);
            return new Polynomial(newCoeffients);
        }

        public static Polynomial operator *(int number, Polynomial a)
        {
            return a * number;
        }

        /// <summary>
        /// Determines whether two polynomials have the same coefficients.
        /// </summary>
        /// <param name="a">The first polynomial to compare.</param>
        /// <param name="b">The second polynomial to compare.</param>
        /// <returns>true if the coefficients of a is the same as the coefficients of b; otherwise, false.</returns>
        public static bool operator ==(Polynomial a, Polynomial b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Determines whether two polynomials have different coefficients.
        /// </summary>
        /// <param name="a">The first polynomial to compare.</param>
        /// <param name="b">The second polynomial to compare.</param>
        /// <returns>true if the coefficients of a is different from the coefficients of b; otherwise, false.</returns>
        public static bool operator !=(Polynomial a, Polynomial b)
        {
            return !a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            var polynomial = (Polynomial)obj;
            if (this.coefficients.Length != polynomial.coefficients.Length)
            {
                return false;
            }

            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (this.coefficients[i] != polynomial.coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.coefficients.GetHashCode();
        }

        public override string ToString()
        {
            if (this.coefficients.Length == 0)
            {
                return string.Empty;
            }

            var sbBuilder = new StringBuilder();
            sbBuilder.Append($"{this.coefficients[0]}X^{this.coefficients.Length - 1}");
            for (int i = 1; i < this.coefficients.Length; i++)
            {
                if (this.coefficients[i] == 0)
                {
                    continue;
                }

                if (this.coefficients[i] > 0)
                {
                    sbBuilder.Append($" + {this.coefficients[i]}X^{this.coefficients.Length - i - 1}");
                }
                else
                {
                    sbBuilder.Append($" {this.coefficients[i]}X^{this.coefficients.Length - i - 1}");
                }
            }

            return sbBuilder.ToString();
        }

        #region Private methods
        private static int[] AdditionArray(int[] array1, int[] array2)
        {
            int[] smallerArray;
            int[] resultArray;
            if (array1.Length == array2.Length)
            {
                resultArray = new int[array1.Length];
                Array.Copy(array1, resultArray, array1.Length);
                for (int i = 0; i < resultArray.Length; i++)
                {
                    resultArray[i] += array2[i];
                }

                return resultArray;
            }

            if (array1.Length > array2.Length)
            {
                resultArray = new int[array1.Length];
                Array.Copy(array1,resultArray, array1.Length);
                smallerArray = array2;
            }
            else
            {
                resultArray = new int[array2.Length];
                Array.Copy(array2, resultArray, array2.Length);
                smallerArray = array1;
            }

            int difLength = resultArray.Length - smallerArray.Length;
            for (int i = resultArray.Length - 1; i > 0; i--)
            {
                resultArray[i] += smallerArray[i - difLength];
            }

            return resultArray;
        }

        private static int[] MultiplicationByNumber(int[] array, int number)
        {
            int[] resultArray = new int[array.Length];
            Array.Copy(array, resultArray, array.Length);
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] *= number;
            }

            return resultArray;
        }
        #endregion
    }
}
