namespace Exchange.Core.Models
{
    public interface IOperationResult
    {
        bool Succeeded { get; }
        string Message { get; }
        object Data { get; }
    }
}