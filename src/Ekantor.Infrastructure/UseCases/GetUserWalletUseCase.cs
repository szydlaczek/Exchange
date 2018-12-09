using Exchange.Core.Models;
using Exchange.Infrastructure.Context;
using Exchange.Infrastructure.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.UseCases
{
    public class GetUserWalletUseCase : UseCase, IUseCase
    {
        public GetUserWalletUseCase(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IRequestResult> Get(string userId)
        {
            User user = await _context.Users.Include(w => w.Wallet).Where(u => u.Id == userId).FirstOrDefaultAsync();
            var result = new UserWalletViewModel
            {
                AmountPLN = user.Wallet.AmountPLN,
                Currencies = user.Wallet.Currencies.Select(c => new UserCurrencyViewModel
                {
                    Id = c.Id,
                    Currency = c.Currency.Code,
                    UnitPrice = Math.Round(c.Currency.GetLastPurchaseValue(), 2),
                    Amount = c.Quantity,
                    Value = Math.Round(c.GetValue(), 2)
                }).ToList()
            };
            return new RequestResult(true, result);
        }
    }
}