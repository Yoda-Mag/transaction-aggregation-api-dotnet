namespace TransactionAggregationApi.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool isMoneyIn{ get; set; }
    }
}
