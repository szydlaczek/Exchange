using System.ComponentModel.DataAnnotations.Schema;

namespace Exchange.Core.Models
{
    public class UserWalletCurrency
    {
        public int Id { get; protected set; }

        [ForeignKey("UserWallet")]
        public string UserWalletId { get; protected set; }

        public virtual UserWallet UserWallet { get; protected set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; protected set; }

        public virtual Currency Currency { get; protected set; }
        public int Quantity { get; protected set; }

        protected UserWalletCurrency()
        {
        }

        public UserWalletCurrency(Currency currency, int quantity)
        {
            Quantity = quantity;
            Currency = currency;
        }

        public void ChangeQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public decimal GetValue()
        {
            return (decimal)((Quantity / Currency.Unit) * Currency.GetLastPurchaseValue());
        }
    }
}