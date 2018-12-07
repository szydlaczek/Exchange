using Exchange.Infrastructure.UseCases;
using Exchange.Infrastructure.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Commands
{
    public class PurchaseCurrencyCommand : IRequest<IRequestResult>
    {
        public string UserId { get; set; }
        public PurchaseCurrencyViewModel Data { get; set; }
    }
}
