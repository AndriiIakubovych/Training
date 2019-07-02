using System;

namespace Figures
{
    class SideLessThanHeightException : SetFigureImpossibilityException
    {
        public SideLessThanHeightException() : base() { }
        public SideLessThanHeightException(string message) : base(message) { }
        public SideLessThanHeightException(string message, Exception innerException) : base(message, innerException) { }
        public SideLessThanHeightException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}