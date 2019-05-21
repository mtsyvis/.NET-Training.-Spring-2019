namespace No3.Solution.First_way
{
    using System;
    using System.Collections.Generic;

    public class Calculator
    {
        public double CalculateAverage(List<double> values, IAverageCalculateMethod calculateMethod)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return calculateMethod.Calculate(values);
        }
    }
}
