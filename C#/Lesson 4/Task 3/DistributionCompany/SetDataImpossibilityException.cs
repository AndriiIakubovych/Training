using System;

namespace DistributionCompany
{
    class SetDataImpossibilityException : ApplicationException
    {
        public SetDataImpossibilityException() : base() { }
        public SetDataImpossibilityException(string message) : base(message) { }
        public SetDataImpossibilityException(string message, Exception innerException) : base(message, innerException) { }
        public SetDataImpossibilityException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}