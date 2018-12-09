using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Exchange.Core.Models
{
    public class UserWallet
    {
        [ForeignKey("User")]
        [Key]
        public string UserId { get; protected set; }

        public virtual User User { get; protected set; }
        public decimal AmountPLN { get; protected set; }
        public virtual ICollection<UserWalletCurrency> Currencies { get; protected set; }

        protected UserWallet()
        {
            Currencies = new HashSet<UserWalletCurrency>();
        }

        public UserWallet(decimal amountPLN)
        {
            AmountPLN = amountPLN;
            Currencies = new HashSet<UserWalletCurrency>();
        }

        public void SetAmount(decimal amountPLN)
        {
            AmountPLN += amountPLN;
        }

        public IOperationResult BuyCurrency(Currency currency, int value, decimal price)
        {
            if (AmountPLN < price)
            {
                return new OperationResult(false, "You don't have enought money", null);
            }

            var walletCurrency = Currencies.Where(c => c.CurrencyId == currency.Id).FirstOrDefault();
            if (walletCurrency == null)
            {
                Currencies.Add(new UserWalletCurrency(currency, value));
            }
            else
            {
                walletCurrency.ChangeQuantity(value);
            }

            AmountPLN -= price;
            return new OperationResult(true, string.Empty, null);
        }

        public IOperationResult SellCurrency(Currency currency, int value, double price)
        {
            var walletCurrency = Currencies.Where(c => c.CurrencyId == currency.Id).FirstOrDefault();
            if (walletCurrency.Quantity < value)
                return new OperationResult(false, "You don't have enought currency", null);
            walletCurrency.ChangeQuantity(-value);
            AmountPLN += (decimal)price;
            return new OperationResult(true, string.Empty, null);
        }
    }
}