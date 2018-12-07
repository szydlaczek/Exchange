using Exchange.Core.Models;
using Exchange.Infrastructure.Context;
using Exchange.Infrastructure.Sheduler;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.UseCases
{
    public class PurchaseCurrencyUseCase : UseCase, IUseCase
    {
        public PurchaseCurrencyUseCase(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IRequestResult> Purchase(string userId, int currencyId, int value)
        {
            if (value<=0)
                return new RequestResult(false, new List<string> { "Please enter quantity greater than 0" }, null);
            if (!Shared.Instance.ApiIsAlive)
                return new RequestResult(false, new List<string> { "Currency server is unavailable" }, null);

            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                User user = await _context.Users.Include(w => w.Wallet).Where(u => u.Id == userId).FirstOrDefaultAsync();
                SystemWallet systemWallet = _context.SystemWallet.Include(c => c.AvailableCurrencies).FirstOrDefault();
                Currency currency = await _context.Currencies.Where(c => c.Id == currencyId).FirstOrDefaultAsync();
                try
                {
                    var sellResult = systemWallet.SellCurrency(value, currencyId);
                    if (sellResult.Succeeded)
                    {
                        await _context.SaveChangesAsync();
                        var buyResult = user.Wallet.BuyCurrency(currency, value, (decimal)sellResult.Data);
                        if (buyResult.Succeeded)
                        {
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            transaction.Rollback();
                            return new RequestResult(false, new List<string> { buyResult.Message }, null);
                        }
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                        return new RequestResult(false, new List<string> { sellResult.Message }, null);
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();
                    await _context.Entry(systemWallet).ReloadAsync();
                    return await this.Purchase(userId, currencyId, value);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new RequestResult(false, new List<string> { "Something goes wrong, please try again later"}, null);
                }
            }
            return new RequestResult(true, null);
        }
    }
}