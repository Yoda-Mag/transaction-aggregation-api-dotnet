using TransactionAggregationApi.Models;

namespace TransactionAggregationApi.Data
{
    public static class MockDataSource
    {
        public static List<Customer> Customers = new List<Customer>
        {
            //Adding instance of customers
            new Customer { Id = Guid.NewGuid(), Name = "Alice",Surname = "Just", Email = "Alice@theBoaderland.com" },
            new Customer { Id = Guid.NewGuid(), Name = "Bob",Surname = "Fischer", Email = "Bobby@icloud.com" },
            new Customer { Id = Guid.NewGuid(), Name = "Charlie",Surname = "Brooker", Email = "CharlieBrooker@gmail.com"}
        };

        public static List<Transaction> Transactions = new List<Transaction>();
    }
}
