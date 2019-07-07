using System;

namespace Figures
{
    class WrongCountException : SetFigureImpossibilityException
    {
        public WrongCountException() : base() { }
        public WrongCountException(string message) : base(message) { }
        public WrongCountException(string message, Exception innerException) : base(message, innerException) { }
        public WrongCountException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}