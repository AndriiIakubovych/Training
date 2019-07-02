using System;

namespace Figures
{
    class EqualBasesException : SetFigureImpossibilityException
    {
        public EqualBasesException() : base() { }
        public EqualBasesException(string message) : base(message) { }
        public EqualBasesException(string message, Exception innerException) : base(message, innerException) { }
        public EqualBasesException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}