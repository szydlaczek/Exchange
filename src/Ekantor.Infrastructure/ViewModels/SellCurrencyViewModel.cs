using System.ComponentModel;

namespace Exchange.Infrastructure.ViewModels
{
    public class SellCurrencyViewModel
    {
        public int CurrencyId { get; set; }

        [DisplayName("Quantity to sell")]
        public int Value { get; set; }
    }
}