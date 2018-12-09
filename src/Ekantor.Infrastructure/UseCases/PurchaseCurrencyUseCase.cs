using Exchange.Core.Models;
using Exchange.Infrastructure.Context;
using Exchange.Infrastructure.Sheduler;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.UseCases
{
    public class PurchaseCurrencyUseCase : UseCase, IUseCase
    {
        private readonly TransactionUseCase _useCase;

        public PurchaseCurrencyUseCase(ApplicationDbContext context, TransactionUseCase useCase) : base(context)
        {
            _useCase = useCase;
        }

        public async Task<IRequestResult> Purchase(string userId, int currencyId, int value)
        {
            if (value <= 0)
                return new RequestResult(false, new List<string> { "Please enter quantity greater than 0" }, null);
            if (!Shared.Instance.ApiIsAlive)
                return new RequestResult(false, new List<string> { "Currency server is unavailable" }, null);

            User user = await _context.Users.Include(w => w.Wallet).Where(u => u.Id == userId).FirstOrDefaultAsync();
            SystemWallet systemWallet = _context.SystemWallet.Include(c => c.AvailableCurrencies).FirstOrDefault();
            Currency currency = await _context.Currencies.Where(c => c.Id == currencyId).FirstOrDefaultAsync();

            return await _useCase.MakeTransaction(systemWallet, user, currency, value);
        }
    }
}