using Exchange.Infrastructure.UseCases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
