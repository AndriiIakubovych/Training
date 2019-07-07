using System;

namespace DistributionCompany
{
    class ExpiredGoodsException : SetDataImpossibilityException
    {
        public ExpiredGoodsException() : base() { }
        public ExpiredGoodsException(string message) : base(message) { }
        public ExpiredGoodsException(string message, Exception innerException) : base(message, innerException) { }
        public ExpiredGoodsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}