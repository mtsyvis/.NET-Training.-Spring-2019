using System;
using System.Text;

namespace NET1.S._2019.Tsyvis._04
{
    /// <summary>
    /// Provide manipulation with polynomials.
    /// </summary>
    public sealed class Polynomial : IEquatable<Polynomial>, ICloneable
    {
        /// <summary>
        /// The epsilon
        /// </summary>
        private static readonly double Epsilon;

        /// <summary>
        /// The coefficients of polynomial.
        /// </summary>
        private readonly double[] coefficients;

        /// <summary>
        /// Initializes the <see cref="Polynomial"/> class.
        /// </summary>
        static Polynomial()
        {
            try
            {
                Epsilon = double.Parse(System.Configuration.ConfigurationManager.AppSettings["epsilon"]);
            }
            catch
            {
                Epsilon = double.Epsilon;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Polynomial.
        /// </summary>
        /// <param name="coefficients">The coefficients to initializing.</param>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException($"coefficients is null{nameof(coefficients)}");
            }

            if (coefficients.Length <= 1)
            {
                throw new ArgumentException($"amount of coefficients must be more then 1{nameof(coefficients.Length)}");
            }

            this.coefficients = new double[coefficients.Length];
            Array.Copy(coefficients, this.coefficients, coefficients.Length);
            this.coefficients = coefficients;
        }

        /// <summary>
        /// Adds polynomials using coefficients.
        /// </summary>
        /// <param name="left">The first polynomial to addition.</param>
        /// <param name="right">The second polynomial to addition.</param>
        /// <returns>result polynomial</returns>
        /// <exception cref="ArgumentNullException">unable to perform addition with null</exception>
        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            if (right == null || left == null)
            {
                throw new ArgumentNullException($"unable to perform addition with null{nameof(right)} {nameof(left)}");
            }

            double[] newCoefficients = AdditionArray(left.coefficients, right.coefficients);
            return new Polynomial(newCoefficients);
        }

        /// <summary>
        /// Subtracts polynomials using coefficients
        /// </summary>
        /// <param name="left">The first polynomial to subtraction.</param>
        /// <param name="right">The second polynomial to subtraction.</param>
        /// <returns>result polynomial</returns>
        /// <exception cref="ArgumentNullException">unable to perform subtraction with null</exception>
        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            if (right == null || left == null)
            {
                throw new ArgumentNullException($"unable to perform subtraction with null{nameof(right)}{nameof(left)}");
            }

            double[] newCoefficientsRightOperand = MultiplicationByNumber(right.coefficients, -1);
            double[] newCoefficients = AdditionArray(left.coefficients, newCoefficientsRightOperand);
            return new Polynomial(newCoefficients);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">unable to perform multiplication with null</exception>
        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            if (right == null || left == null)
            {
                throw new ArgumentNullException($"unable to perform multiplication with null{nameof(right)}{nameof(left)}");
            }

            double[] newCoefficients = new double[left.coefficients.Length + right.coefficients.Length - 1];
            for (int i = 0; i < left.coefficients.Length; ++i)
            {
                for (int j = 0; j < right.coefficients.Length; ++j)
                {
                    newCoefficients[i + j] += left.coefficients[i] * right.coefficients[j];
                }
            }

            return new Polynomial(newCoefficients);
        }

        /// <summary>
        /// Multiply polynomial by number.
        /// </summary>
        /// <param name="a">The polynomial to multiplication.</param>
        /// <param name="number">The number to multiplication.</param>
        /// <returns>result polynomial</returns>
        /// <exception cref="ArgumentNullException">unable to perform multiplication with null</exception>
        public static Polynomial operator *(Polynomial polynomial, double number)
        {
            if (polynomial == null)
            {
                throw new ArgumentNullException($"unable to perform multiplication with null{nameof(polynomial)}");
            }

            double[] newCoeffients = MultiplicationByNumber(polynomial.coefficients, number);
            return new Polynomial(newCoeffients);
        }

        /// <summary>
        /// Multiply polynomial by number.
        /// </summary>
        /// <param name="a">The polynomial to multiplication.</param>
        /// <param name="number">The number to multiplication.</param>
        /// <returns>result polynomial</returns>
        /// <exception cref="ArgumentNullException">unable to perform multiplication with null</exception>
        public static Polynomial operator *(double number, Polynomial polynomial)
        {
            if (polynomial == null)
            {
                throw new ArgumentNullException($"unable to perform multiplication with null{nameof(polynomial)}");
            }

            return polynomial * number;
        }

        /// <summary>
        /// Determines whether two polynomials have the same coefficients.
        /// </summary>
        /// <param name="left">The first polynomial to compare.</param>
        /// <param name="right">The second polynomial to compare.</param>
        /// <returns>true if the coefficients of a is the same as the coefficients of b; otherwise, false.</returns>
        public static bool operator ==(Polynomial left, Polynomial right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
            {
                return true;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two polynomials have different coefficients.
        /// </summary>
        /// <param name="left">The first polynomial to compare.</param>
        /// <param name="right">The second polynomial to compare.</param>
        /// <returns>true if the coefficients of a is different from the coefficients of b; otherwise, false.</returns>
        public static bool operator !=(Polynomial left, Polynomial right)
        {
            if ((ReferenceEquals(left, null) && !ReferenceEquals(right, null)) ||
                (ReferenceEquals(right, null) && !ReferenceEquals(left, null)))
            {
                return true;
            }

            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
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
                if (this.coefficients[i] - polynomial.coefficients[i] > Epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (this.coefficients.Length != other.coefficients.Length)
            {
                return false;
            }

            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (this.coefficients[i] - other.coefficients[i] > Epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var tempEpsilon = Epsilon;
            int numberRounded = 0;
            while (tempEpsilon < 1) 
            {
                numberRounded++;
                tempEpsilon *= 10;
            }

            int hash = 0;
            foreach (var coefficient in this.coefficients)
            {
                hash += 303 * Math.Round(coefficient, numberRounded).GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            var copyCoefficients = new double[this.coefficients.Length];
            Array.Copy(this.coefficients, copyCoefficients, this.coefficients.Length);
            return new Polynomial(copyCoefficients);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
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

        private static double[] AdditionArray(double[] array1, double[] array2)
        {
            double[] smallerArray;
            double[] resultArray;
            if (array1.Length == array2.Length)
            {
                resultArray = new double[array1.Length];
                Array.Copy(array1, resultArray, array1.Length);
                for (int i = 0; i < resultArray.Length; i++)
                {
                    resultArray[i] += array2[i];
                }

                return resultArray;
            }

            if (array1.Length > array2.Length)
            {
                resultArray = new double[array1.Length];
                Array.Copy(array1,resultArray, array1.Length);
                smallerArray = array2;
            }
            else
            {
                resultArray = new double[array2.Length];
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

        private static double[] MultiplicationByNumber(double[] array, double number)
        {
            double[] resultArray = new double[array.Length];
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
