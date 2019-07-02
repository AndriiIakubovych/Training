using System;

namespace Figures
{
    class WrongBaseException : SetFigureImpossibilityException
    {
        public WrongBaseException() : base() { }
        public WrongBaseException(string message) : base(message) { }
        public WrongBaseException(string message, Exception innerException) : base(message, innerException) { }
        public WrongBaseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}