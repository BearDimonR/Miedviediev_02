using System;

namespace Miedviediev_02.Exceptions
{
    public class InvalidPersonName : ApplicationException
    {
        public InvalidPersonName(string name) :
            base($"Invalid Person name: \n {name} \n Mustn't contain something except letters!")
        {}
    }
}