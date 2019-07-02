using System;

namespace Figures
{
    class WrongSidesException : SetFigureImpossibilityException
    {
        public WrongSidesException() : base() { }
        public WrongSidesException(string message) : base(message) { }
        public WrongSidesException(string message, Exception innerException) : base(message, innerException) { }
        public WrongSidesException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}