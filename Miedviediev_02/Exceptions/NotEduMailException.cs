using System;

namespace Miedviediev_02.Exceptions
{
    public class NotEduMailException : ApplicationException
    {
        public NotEduMailException(string email) :
            base($"Not educational email: {email} \n Must be: example@ukma.edu.ua")
        {}
    }
}