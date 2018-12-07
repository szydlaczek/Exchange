namespace Exchange.Infrastructure.ViewModels
{
    public class SystemCurrencyViewModel
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public int Unit { get; set; }
        public decimal Value { get; set; }
        public string LastRateDate { get; set; }
    }
}