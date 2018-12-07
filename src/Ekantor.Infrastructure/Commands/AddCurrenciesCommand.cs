using Exchange.Infrastructure.Dtos;
using MediatR;

namespace Exchange.Infrastructure.Commands
{
    public class AddCurrenciesCommand : IRequest
    {
        public CurrenciesDto CurrenciesDto { get; set; }
    }
}