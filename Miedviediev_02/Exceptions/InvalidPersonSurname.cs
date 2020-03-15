using System;

namespace Miedviediev_02.Exceptions
{
    public class InvalidPersonSurname : ApplicationException
    {
        public InvalidPersonSurname(string surname) :
            base($"Invalid Person surname: \n {surname} \n Mustn't contain something except letters!")
        {}
    }
}