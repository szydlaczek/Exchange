using System.ComponentModel;

namespace Exchange.Infrastructure.ViewModels
{
    public class PurchaseCurrencyViewModel
    {
        public int CurrencyId { get; set; }

        [DisplayName("Quantity to buy")]
        public int Value { get; set; }
    }
}