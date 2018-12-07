using Exchange.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Context
{
    public class ExchangeDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            SystemWallet systemWallet = new SystemWallet(2500);
            List<Currency> currencies = new List<Currency>()
            {
                 new Currency("US Dollar", "USD", 1, new CurrencyValue(3.9198, 3.9353, 3.9276,
                    DateTime.Parse("2018-12-07T20:26:34.7383704Z"))),

                 new Currency("Euro", "EUR", 1,new CurrencyValue(4.0542, 4.0687, 4.0615,
                    DateTime.Parse("2018-12-07T20:26:34.7383704Z"))),

                 new Currency("Swiss Franc", "CHF", 1, new CurrencyValue(4.0617, 4.0674, 4.0646,
                    DateTime.Parse("2018-12-07T20:26:34.7383704Z"))),

                 new Currency("Russian ruble", "RUB", 100, new CurrencyValue(7.2809, 7.2929, 7.2869,
                    DateTime.Parse("2018-12-07T20:26:34.7383704Z"))),

                 new Currency("Czech koruna", "CZK", 100, new CurrencyValue(14.6004, 14.6290, 14.6147,
                    DateTime.Parse("2018-12-07T20:26:34.7383704Z"))),

                 new Currency("Pound sterling", "GBP", 1, new CurrencyValue(5.5999, 5.6068, 5.6034,
                    DateTime.Parse("2018-12-07T20:26:34.7383704Z")))
            };

            foreach (var currency in currencies)
            {
                systemWallet.AvailableCurrencies.Add(new SystemWalletCurrency(500, currency));
            }
            context.SystemWallet.Add(systemWallet);
            base.Seed(context);
        }
    }
}
