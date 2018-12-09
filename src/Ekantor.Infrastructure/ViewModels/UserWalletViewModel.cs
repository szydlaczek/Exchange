using System;
using System.Collections.Generic;

namespace Exchange.Infrastructure.ViewModels
{
    public class UserWalletViewModel
    {
        public Decimal AmountPLN { get; set; }
        public ICollection<UserCurrencyViewModel> Currencies { get; set; }
    }
}