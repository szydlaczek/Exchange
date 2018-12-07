using System.Collections.Generic;

namespace Exchange.Infrastructure.UseCases
{
    public interface IRequestResult
    {
        bool Succeeded { get; }
        IEnumerable<string> Errors { get; }
        object Data { get; }
    }
}