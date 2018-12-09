using Exchange.Infrastructure.Commands;
using Exchange.Infrastructure.UseCases;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Handlers
{
    public class PurchaseCurrencyHandler : IRequestHandler<PurchaseCurrencyCommand, IRequestResult>
    {
        private readonly PurchaseCurrencyUseCase _useCase;

        public PurchaseCurrencyHandler(PurchaseCurrencyUseCase useCase)
        {
            _useCase = useCase;
        }

        public Task<IRequestResult> Handle(PurchaseCurrencyCommand request, CancellationToken cancellationToken)
        {
            return _useCase.Purchase(request.UserId, request.Data.CurrencyId, request.Data.Value);
        }
    }
}