using System;

namespace Figures
{
    class NotSimplePolygonException : SetFigureImpossibilityException
    {
        public NotSimplePolygonException() : base() { }
        public NotSimplePolygonException(string message) : base(message) { }
        public NotSimplePolygonException(string message, Exception innerException) : base(message, innerException) { }
        public NotSimplePolygonException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}