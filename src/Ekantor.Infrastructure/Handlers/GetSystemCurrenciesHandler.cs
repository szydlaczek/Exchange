using Exchange.Infrastructure.Queries;
using Exchange.Infrastructure.UseCases;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Handlers
{
    public class GetSystemCurrenciesHandler : IRequestHandler<SystemCurrenciesQuery, IRequestResult>
    {
        private readonly GetSystemCurrenciesUseCase _useCase;

        public GetSystemCurrenciesHandler(GetSystemCurrenciesUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task<IRequestResult> Handle(SystemCurrenciesQuery request, CancellationToken cancellationToken)
        {
            return await _useCase.GetCurrencies();
        }
    }
}