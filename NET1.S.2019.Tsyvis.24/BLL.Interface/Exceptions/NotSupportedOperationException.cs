using System;

namespace BLL.Interface.Exceptions
{
    public class NotSupportedOperationException : Exception
    {
        public NotSupportedOperationException(string message) : base(message) { }
    }
}
