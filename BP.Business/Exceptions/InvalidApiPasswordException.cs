using System;

namespace BP.Exceptions
{
    public class InvalidApiPasswordException : Exception
    {
        public InvalidApiPasswordException()
        {
        }

        public InvalidApiPasswordException(string message)
            : base(message)
        {
        }

        public InvalidApiPasswordException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
