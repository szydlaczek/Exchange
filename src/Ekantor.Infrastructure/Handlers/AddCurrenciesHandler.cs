using Exchange.Infrastructure.Commands;
using Exchange.Infrastructure.UseCases;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Handlers
{
    public class AddCurrenciesHandler : AsyncRequestHandler<AddCurrenciesCommand>
    {
        private readonly AddCurrenciesUseCase _useCase;

        public AddCurrenciesHandler(/*AddCurrenciesUseCase useCase*/)
        {
            _useCase = new AddCurrenciesUseCase();
        }

        protected override async Task Handle(AddCurrenciesCommand request, CancellationToken cancellationToken)
        {
            await _useCase.Add(request.CurrenciesDto);
        }
    }
}