using System;

namespace Miedviediev_02.Exceptions
{
    public class AgeException : ApplicationException
    {
        protected AgeException(string message): 
                base(message)
            {}
    }
}