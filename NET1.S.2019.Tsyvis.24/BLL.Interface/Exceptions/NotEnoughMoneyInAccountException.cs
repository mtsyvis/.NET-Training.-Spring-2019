using System;

namespace BLL.Interface.Exceptions
{
    public class NotEnoughMoneyInAccountException : Exception
    {
        public double Balance { get; }

        public NotEnoughMoneyInAccountException(string message, double balance)
            : base(message)
        {
            Balance = balance;
        }

        public NotEnoughMoneyInAccountException(string message) : base(message) { }
    }
}
