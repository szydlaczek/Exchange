using Exchange.Infrastructure.Context;
using Exchange.Infrastructure.ViewModels;
using System.Data.Entity;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.UseCases
{
    public class GetSystemCurrenciesUseCase : UseCase, IUseCase
    {
        public GetSystemCurrenciesUseCase(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IRequestResult> GetCurrencies()
        {
            
            var wallet = await _context.SystemWallet
                .Include(c => c.AvailableCurrencies)
                .FirstOrDefaultAsync();

            var result = wallet.AvailableCurrencies.Select(d => new SystemCurrencyViewModel
            {
                Currency = d.Currency.Code,
                Id = d.Currency.Id,
                Unit = d.Currency.Unit,
                Value = Math.Round((decimal)d.Currency.GetLastSellValue(), 2),
                LastRateDate = d.Currency.Values
                .OrderByDescending(p => p.PublicationDate)
                .FirstOrDefault().PublicationDate.ToString("yyyy-MM-dd HH:mm:ss")
            })
            .ToList();

            return new RequestResult(true, result);
        }
    }
}