using Exchange.Infrastructure.Commands;
using Exchange.Infrastructure.UseCases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Handlers
{
    public class SellCurrencyHandler : IRequestHandler<SellCurrencyCommand, IRequestResult>
    {
        private readonly SellCurrencyUseCase _useCase;
        public SellCurrencyHandler(SellCurrencyUseCase useCase)
        {
            _useCase = useCase;
        }
        public async Task<IRequestResult> Handle(SellCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _useCase.Sell(request.UserId, request.Data.CurrencyId, request.Data.Value);
        }
    }
}
