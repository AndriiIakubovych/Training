namespace Blog.BusinessLogicLayer.Infrastructure
{
    public class OperationDetails
    {
        public OperationDetails(bool succeed, string message, string property)
        {
            Succeed = succeed;
            Message = message;
            Property = property;
        }

        public bool Succeed { get; private set; }

        public string Message { get; private set; }

        public string Property { get; private set; }
    }
}