using System;

namespace Figures
{
    class NegativeHeightException : SetFigureImpossibilityException
    {
        public NegativeHeightException() : base() { }
        public NegativeHeightException(string message) : base(message) { }
        public NegativeHeightException(string message, Exception innerException) : base(message, innerException) { }
        public NegativeHeightException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}