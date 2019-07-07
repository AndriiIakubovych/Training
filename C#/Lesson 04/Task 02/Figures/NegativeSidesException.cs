using System;

namespace Figures
{
    class NegativeSidesException : SetFigureImpossibilityException
    {
        public NegativeSidesException() : base() { }
        public NegativeSidesException(string message) : base(message) { }
        public NegativeSidesException(string message, Exception innerException) : base(message, innerException) { }
        public NegativeSidesException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}