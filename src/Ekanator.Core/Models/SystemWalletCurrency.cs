using System.ComponentModel.DataAnnotations.Schema;

namespace Exchange.Core.Models
{
    public class SystemWalletCurrency
    {
        public int Id { get; protected set; }
        public int Ammount { get; protected set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; protected set; }

        public virtual Currency Currency { get; protected set; }

        [ForeignKey("SystemWallet")]
        public int SystemWalletId { get; protected set; }

        public virtual SystemWallet SystemWallet { get; protected set; }

        protected SystemWalletCurrency()
        {
        }

        public SystemWalletCurrency(int amount, Currency currency)
        {
            Ammount = amount;
            Currency = currency;
        }

        public void AddAmount(int amount)
        {
            Ammount += amount;
        }
    }
}