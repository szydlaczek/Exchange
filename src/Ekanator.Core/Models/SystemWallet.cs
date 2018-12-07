using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Exchange.Core.Models
{
    public class SystemWallet
    {
        public int Id { get; protected set; }

        [ConcurrencyCheck]
        public decimal AmountPLN { get; protected set; }

        public virtual ICollection<SystemWalletCurrency> AvailableCurrencies { get; protected set; }

        protected SystemWallet()
        {
            AvailableCurrencies = new HashSet<SystemWalletCurrency>();
        }

        public SystemWallet(decimal amountPLN)
        {
            AmountPLN = amountPLN;
            AvailableCurrencies = new HashSet<SystemWalletCurrency>();
        }

        public IOperationResult SellCurrency(int value, int currencyId)
        {
            var walletCurrency = AvailableCurrencies.Where(c => c.CurrencyId == currencyId).FirstOrDefault();
            var unit = walletCurrency.Currency.Unit;
            if (value % unit != 0)
                return new OperationResult(false, $"You cannot buy {value}. You can buy multiplicity of unit", null);
            if (walletCurrency.Ammount < value)
                return new OperationResult(false, $"No enought {walletCurrency.Currency.Code} in system", null);

            walletCurrency.AddAmount(-value);            
            var price = (decimal)((value / unit) * walletCurrency.Currency.GetLastSellValue());
            AmountPLN += price;
            return new OperationResult(true, string.Empty, price);
        }
    }
}