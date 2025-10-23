using TransactionAggregationApi.Models;

namespace TransactionAggregationApi.Data
{
    public static class MockDataSource
    {
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer { Id = Guid.NewGuid(), Name = "Alice", Email = "Alice@theBoaderland.com" },
            new Customer { Id = Guid.NewGuid(), Name = "Bob", Email = "Bobby@icloud.com" },
            new Customer { Id = Guid.NewGuid(), Name = "Charlie" }
        };

        public static List<Transaction> Transactions = new List<Transaction>();
    }
}
