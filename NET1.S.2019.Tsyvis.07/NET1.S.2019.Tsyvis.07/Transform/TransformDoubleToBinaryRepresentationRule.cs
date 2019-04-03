using System;

namespace NET1.S._2019.Tsyvis._07.Transform
{
    /// <summary>
    /// Provide transforming real number to binary representation.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._07.Transform.ITransformDoubleRule" />
    public class TransformDoubleToBinaryRepresentationRule : ITransformDoubleRule
    {
        /// <summary>
        /// Transforms the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// binary representation of real number
        /// </returns>
        public string Transform(double number)
        {
            long bits = BitConverter.DoubleToInt64Bits(number);
            return Convert.ToString(bits, 2).PadLeft(64, '0');
        }
    }
}
