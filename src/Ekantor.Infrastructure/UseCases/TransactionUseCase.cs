using Exchange.Core.Models;
using Exchange.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.UseCases
{
    public class TransactionUseCase : UseCase, IUseCase
    {
        public TransactionUseCase(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IRequestResult> MakeTransaction(ISellCurrency From, IBuyCurrency To, Currency currency, int quantity)
        {
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var sellResult = await From.SellCurrency(currency, quantity);
                    if (!sellResult.Succeeded)
                        return new RequestResult(false, new List<string> { sellResult.Message }, null);
                    await _context.SaveChangesAsync();
                    var buyResult = await To.BuyCurrency(currency, quantity);
                    if (!buyResult.Succeeded)
                        return new RequestResult(false, new List<string> { buyResult.Message }, null);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();
                    await _context.Entry(From).ReloadAsync();
                    await _context.Entry(To).ReloadAsync();
                    return await this.MakeTransaction(From, To, currency, quantity);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new RequestResult(false, new List<string> { "Something goes wrong, please try again later" }, null);
                }
                return new RequestResult(true, null);
            }
        }
    }
}