using System;

namespace Figures
{
    class WrongCoordinatesException : SetFigureImpossibilityException
    {
        public WrongCoordinatesException() : base() { }
        public WrongCoordinatesException(string message) : base(message) { }
        public WrongCoordinatesException(string message, Exception innerException) : base(message, innerException) { }
        public WrongCoordinatesException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}