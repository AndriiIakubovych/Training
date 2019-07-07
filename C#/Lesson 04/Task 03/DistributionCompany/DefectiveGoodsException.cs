using System;

namespace DistributionCompany
{
    class DefectiveGoodsException : SetDataImpossibilityException
    {
        public DefectiveGoodsException() : base() { }
        public DefectiveGoodsException(string message) : base(message) { }
        public DefectiveGoodsException(string message, Exception innerException) : base(message, innerException) { }
        public DefectiveGoodsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}