using System;

namespace DistributionCompany
{
    class WrongValueException : SetDataImpossibilityException
    {
        public WrongValueException() : base() { }
        public WrongValueException(string message) : base(message) { }
        public WrongValueException(string message, Exception innerException) : base(message, innerException) { }
        public WrongValueException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}