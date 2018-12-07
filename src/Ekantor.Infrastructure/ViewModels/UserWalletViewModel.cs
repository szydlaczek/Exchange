using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.ViewModels
{
    public class UserWalletViewModel
    {
        public Decimal AmountPLN { get; set; }
        public ICollection<UserCurrencyViewModel> Currencies { get; set; }
        
    }
}
