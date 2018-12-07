using Exchange.Core.Models;
using Exchange.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.UseCases
{
    public class SellCurrencyUseCase : UseCase, IUseCase
    {
        public SellCurrencyUseCase(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IRequestResult> Sell(string userId, int currencyId, int value)
        {
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                User user = await _context.Users.Include(w => w.Wallet).Where(u => u.Id == userId).FirstOrDefaultAsync();
                SystemWallet systemWallet = _context.SystemWallet.Include(c => c.AvailableCurrencies).FirstOrDefault();
                try
                {

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();
                    await _context.Entry(systemWallet).ReloadAsync();
                    await _context.Entry(user.Wallet).ReloadAsync();
                    return await this.Sell(userId, currencyId, value);
                }
                catch (Exception exc)
                {
                    //log
                }
                return new RequestResult(true, null);
            }
        }
    }
}
