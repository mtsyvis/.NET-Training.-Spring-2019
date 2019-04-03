﻿namespace NET1.S._2019.Tsyvis._07.Transform
{
    /// <summary>
    /// Defines an interface for transforming doule.
    /// </summary>
    public interface ITransformDoubleRule
    {
        /// <summary>
        /// Transforms the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>string representation</returns>
        string Transform(double number);
    }
}
