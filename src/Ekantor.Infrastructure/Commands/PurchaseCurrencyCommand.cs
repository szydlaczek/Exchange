using Exchange.Infrastructure.UseCases;
using Exchange.Infrastructure.ViewModels;
using MediatR;

namespace Exchange.Infrastructure.Commands
{
    public class PurchaseCurrencyCommand : IRequest<IRequestResult>
    {
        public string UserId { get; set; }
        public PurchaseCurrencyViewModel Data { get; set; }
    }
}