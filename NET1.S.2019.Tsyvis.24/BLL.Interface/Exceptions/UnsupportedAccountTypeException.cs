using System;

namespace BLL.Interface.Exceptions
{
    public class UnsupportedAccountTypeException : Exception
    {
        public UnsupportedAccountTypeException(string message) : base() { }
    }
}
