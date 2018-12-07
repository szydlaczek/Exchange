using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.ViewModels
{
    public class SellCurrencyViewModel
    {
        public int CurrencyId { get; set; }
        [DisplayName("Quantity to sell")]
        public int Value { get; set; }
    }
}
