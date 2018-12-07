using Exchange.Infrastructure.Commands;
using Exchange.Infrastructure.Dtos;
using Exchange.Infrastructure.Providers;
using Exchange.Infrastructure.Sheduler;
using Exchange.Infrastructure.UseCases;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Handlers
{
    public class UpdateValuesFromApiHandler : AsyncRequestHandler<UpdateValuesFromApiCommand>
    {
        private readonly ICurrencyProvider _currencyProvider;
        private readonly AddCurrenciesUseCase _useCase;

        public UpdateValuesFromApiHandler(ICurrencyProvider currencyProvider, AddCurrenciesUseCase useCase)
        {
            _currencyProvider = currencyProvider;
            _useCase = useCase;
        }

        protected override async Task Handle(UpdateValuesFromApiCommand request, CancellationToken cancellationToken)
        {
            try
            {
                CurrenciesDto result = await _currencyProvider.Download();
                await _useCase.Add(result);
                Shared.Instance.ApiIsAlive = true;
            }
            catch (Exception ex)
            {
                Shared.Instance.ApiIsAlive = false;
            }
        }
    }
}