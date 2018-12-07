namespace Exchange.Infrastructure.Dtos
{
    public class CurrencyItemDto
    {
        public double PurchasePrice { get; set; }
        public double SellPrice { get; set; }
        public double AveragePrice { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Unit { get; set; }
    }
}