using System;

namespace Figures
{
    class WrongSemiaxisesException : SetFigureImpossibilityException
    {
        public WrongSemiaxisesException() : base() { }
        public WrongSemiaxisesException(string message) : base(message) { }
        public WrongSemiaxisesException(string message, Exception innerException) : base(message, innerException) { }
        public WrongSemiaxisesException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}