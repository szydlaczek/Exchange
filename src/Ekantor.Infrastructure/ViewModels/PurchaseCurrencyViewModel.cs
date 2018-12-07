using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.ViewModels
{
    public class PurchaseCurrencyViewModel
    {
        public int CurrencyId { get; set; }
        [DisplayName("Quantity to buy")]
        public int Value { get; set; }
    }
}
