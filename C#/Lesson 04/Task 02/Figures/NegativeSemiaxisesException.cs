using System;

namespace Figures
{
    class NegativeSemiaxisesException : SetFigureImpossibilityException
    {
        public NegativeSemiaxisesException() : base() { }
        public NegativeSemiaxisesException(string message) : base(message) { }
        public NegativeSemiaxisesException(string message, Exception innerException) : base(message, innerException) { }
        public NegativeSemiaxisesException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}