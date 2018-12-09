using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Core.Models
{
    public class SystemWallet : ISellCurrency, IBuyCurrency
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

        public async Task<IOperationResult> BuyCurrency(Currency currency, int value)
        {
            if (value % currency.Unit != 0)
                return await Task.FromResult(new OperationResult(false, $"You cannot buy {value}. You can buy multiplicity of unit", null));

            var operationValue = (value / currency.Unit) * currency.GetLastPurchaseValue();
            if (AmountPLN < ((decimal)operationValue))
                return new OperationResult(false, $"No enought PLN in system", null);

            var walletCurrency = AvailableCurrencies.Where(c => c.CurrencyId == currency.Id).FirstOrDefault();
            walletCurrency.AddAmount(value);
            AmountPLN -= (decimal)operationValue;
            return new OperationResult(true, string.Empty, operationValue);
        }

        public async Task<IOperationResult> SellCurrency(Currency currency, int value)
        {
            var walletCurrency = AvailableCurrencies.Where(c => c.CurrencyId == currency.Id).FirstOrDefault();
            var unit = walletCurrency.Currency.Unit;
            if (value % unit != 0)
                return await Task.FromResult(new OperationResult(false, $"You cannot buy {value}. You can buy multiplicity of unit", null));
            if (walletCurrency.Ammount < value)
                return await Task.FromResult(new OperationResult(false, $"No enought {walletCurrency.Currency.Code} in system", null));

            walletCurrency.AddAmount(-value);                                   
            var price = (decimal)((value / unit) * currency.GetLastSellValue());
            AmountPLN += price;
            return new OperationResult(true, string.Empty, price);
        }
    }
}