using System;

namespace OrdersInformation
{
    class DataNotFoundException : SetDataImpossibilityException
    {
        public DataNotFoundException() : base() { }
        public DataNotFoundException(string message) : base(message) { }
        public DataNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        public DataNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}