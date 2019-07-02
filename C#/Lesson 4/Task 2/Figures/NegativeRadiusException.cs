using System;

namespace Figures
{
    class NegativeRadiusException : SetFigureImpossibilityException
    {
        public NegativeRadiusException() : base() { }
        public NegativeRadiusException(string message) : base(message) { }
        public NegativeRadiusException(string message, Exception innerException) : base(message, innerException) { }
        public NegativeRadiusException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}