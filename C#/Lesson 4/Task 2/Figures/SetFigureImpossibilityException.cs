using System;

namespace Figures
{
    class SetFigureImpossibilityException : ApplicationException
    {
        public SetFigureImpossibilityException() : base() { }
        public SetFigureImpossibilityException(string message) : base(message) { }
        public SetFigureImpossibilityException(string message, Exception innerException) : base(message, innerException) { }
        public SetFigureImpossibilityException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}