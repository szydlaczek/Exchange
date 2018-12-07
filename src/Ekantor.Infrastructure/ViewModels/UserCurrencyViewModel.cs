using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.ViewModels
{
    public class UserCurrencyViewModel
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public double UnitPrice { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
        
    }
}
