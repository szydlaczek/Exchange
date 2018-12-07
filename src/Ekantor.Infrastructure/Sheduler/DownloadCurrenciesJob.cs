using Exchange.Infrastructure.Commands;
using Exchange.Infrastructure.Dtos;
using Exchange.Infrastructure.Providers;
using Exchange.Infrastructure.Queries;
using MediatR;
using Quartz;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Sheduler
{
    public class DownloadCurrenciesJob : IJob
    {
        //private ICurrencyProvider _currencyProvider;
        private readonly IMediator _mediator;

        public DownloadCurrenciesJob(IMediator mediator/*, ICurrencyProvider currencyProvider*/)
        {
            //_currencyProvider = currencyProvider;
            _mediator = mediator;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            //try
            //{
            //    var currencies = await _currencyProvider.Download();

            //    await _mediator.Send(new AddCurrenciesCommand
            //    {
            //        CurrenciesDto = currencies
            //    });
            //    Shared.Instance.ApiIsAlive = true;
            //}
            //catch
            //{
            //    Shared.Instance.ApiIsAlive = false;
            //}
            await _mediator.Send(new UpdateValuesFromApiCommand());

            //var result = await _mediator.Send(new ApiCurrenciesValuesQuery());
            //if (result.Succeeded)
            //{
            //    await _mediator.Send(new AddCurrenciesCommand
            //    {
            //        CurrenciesDto = (CurrenciesDto)result.Data
            //    });
            //}                         
        }
    }
}