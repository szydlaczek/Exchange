using Exchange.Core.Models;
using Exchange.Infrastructure.Context;
using Exchange.Infrastructure.Dtos;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.UseCases
{
    public class AddCurrenciesUseCase : IUseCase
    {
        public AddCurrenciesUseCase()
        {
        }

        public async Task Add(CurrenciesDto currenciesDto)
        {
            using (var _context = new ApplicationDbContext())
            {
                var showPiece = _context.CurrencyValues
                       .OrderByDescending(p => p.PublicationDate)
                       .FirstOrDefault();

                if (showPiece == null || showPiece?.PublicationDate.ToShortTimeString() != currenciesDto.PublicationDate.ToShortTimeString())
                {
                    foreach (var currency in currenciesDto.Items)
                    {
                        var currencyModel = await _context.Currencies.Where(c => c.Code == currency.Code).FirstOrDefaultAsync();

                        if (currencyModel == null)
                        {
                            currencyModel = new Currency(currency.Name, currency.Code, currency.Unit);
                            _context.Currencies.Add(currencyModel);
                        }
                        else
                        {
                            currencyModel.Values.Add(new CurrencyValue(currency.PurchasePrice, currency.SellPrice, currency.AveragePrice, currenciesDto.PublicationDate));
                        }
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}