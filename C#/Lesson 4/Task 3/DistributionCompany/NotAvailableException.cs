using System;

namespace DistributionCompany
{
    class NotAvailableException : SetDataImpossibilityException
    {
        public NotAvailableException() : base() { }
        public NotAvailableException(string message) : base(message) { }
        public NotAvailableException(string message, Exception innerException) : base(message, innerException) { }
        public NotAvailableException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}