using Exchange.Infrastructure.UseCases;
using MediatR;

namespace Exchange.Infrastructure.Queries
{
    public class UserCurrenciesQuery : IRequest<IRequestResult>
    {
        public string UserId { get; protected set; }

        public UserCurrenciesQuery(string userId)
        {
            UserId = userId;
        }
    }
}