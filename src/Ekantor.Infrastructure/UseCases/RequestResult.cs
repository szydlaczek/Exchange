using System.Collections.Generic;

namespace Exchange.Infrastructure.UseCases
{
    public class RequestResult : IRequestResult
    {
        public bool Succeeded { get; }

        public IEnumerable<string> Errors { get; }

        public object Data { get; }

        public RequestResult(bool succeeded, List<string> errors, object data)
        {
            Succeeded = succeeded;
            Errors = errors;
            Data = data;
        }

        public RequestResult(bool succeeded, object data)
        {
            Succeeded = succeeded;
            Data = data;
        }
    }
}