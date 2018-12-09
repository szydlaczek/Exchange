using System.Collections.Generic;
using System.Linq;

namespace Exchange.Core.Models
{
    public class Currency
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Code { get; protected set; }
        public int Unit { get; protected set; }
        public virtual ICollection<CurrencyValue> Values { get; protected set; }

        protected Currency()
        {
            Values = new HashSet<CurrencyValue>();
        }

        public Currency(string name, string code, int unit)
        {
            Name = name;
            Code = code;
            Unit = unit;
            Values = new HashSet<CurrencyValue>();
        }

        public Currency(string name, string code, int unit, CurrencyValue currencyValue)
        {
            Name = name;
            Code = code;
            Unit = unit;
            Values = new HashSet<CurrencyValue>();
            Values.Add(currencyValue);
        }

        public double GetLastSellValue()
        {
            return Values.OrderByDescending(p => p.PublicationDate).FirstOrDefault().SellPrice;
        }

        public double GetLastPurchaseValue()
        {
            return Values.OrderByDescending(p => p.PublicationDate).FirstOrDefault().PurchasePrice;
        }
    }
}