using Exchange.Infrastructure.UseCases;
using Exchange.Infrastructure.ViewModels;
using MediatR;

namespace Exchange.Infrastructure.Commands
{
    public class SellCurrencyCommand : IRequest<IRequestResult>
    {
        public string UserId { get; set; }
        public SellCurrencyViewModel Data { get; set; }
    }
}