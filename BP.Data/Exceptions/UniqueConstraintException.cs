using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Exceptions
{
    public class UniqueConstraintException : Exception
    {
        public UniqueConstraintException()
        {
        }

        public UniqueConstraintException(string message)
            : base(message)
        {
        }

        public UniqueConstraintException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
