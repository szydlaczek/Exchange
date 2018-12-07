namespace Exchange.Core.Models
{
    public class OperationResult : IOperationResult
    {
        public bool Succeeded { get; }

        public string Message { get; }

        public object Data { get; }

        public OperationResult(bool succeeded, string message, object data)
        {
            Succeeded = succeeded;
            Message = message;
            Data = data;
        }
    }
}