using System;

namespace BLL.Interface.Exceptions
{
    public class NotEnoughMoneyInAccountException : Exception
    {
        public double Sum { get; }

        NotEnoughMoneyInAccountException(string message, double sum)
            : base(message)
        {
            Sum = sum;
        }

        NotEnoughMoneyInAccountException(string message) : base(message) { }
    }
}
