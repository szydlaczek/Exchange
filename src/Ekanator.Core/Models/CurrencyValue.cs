using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exchange.Core.Models
{
    public class CurrencyValue
    {
        public int Id { get; protected set; }
        public double PurchasePrice { get; protected set; }
        public double SellPrice { get; protected set; }
        public double AveragePrice { get; protected set; }
        public DateTime PublicationDate { get; protected set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; protected set; }

        public virtual Currency Currency { get; protected set; }

        protected CurrencyValue()
        {
        }

        public CurrencyValue(double purchasePrice, double sellPrice, double averagePrice, DateTime publicationDate)
        {
            PurchasePrice = purchasePrice;
            SellPrice = sellPrice;
            AveragePrice = averagePrice;
            PublicationDate = publicationDate;
        }
    }
}