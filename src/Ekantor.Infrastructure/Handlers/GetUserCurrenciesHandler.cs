using Exchange.Infrastructure.Queries;
using Exchange.Infrastructure.UseCases;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Handlers
{
    public class GetUserCurrenciesHandler : IRequestHandler<UserCurrenciesQuery, IRequestResult>
    {
        private readonly GetUserWalletUseCase _useCae;

        public GetUserCurrenciesHandler(GetUserWalletUseCase useCase)
        {
            _useCae = useCase;
        }

        public async Task<IRequestResult> Handle(UserCurrenciesQuery request, CancellationToken cancellationToken)
        {
            return await _useCae.Get(request.UserId);
        }
    }
}