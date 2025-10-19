using TransactionAggregationApi.Models;
using TransactionAggregationApi.Data;

namespace TransactionAggregationApi.Data
{
    public static class RichBankData
    {
        public static List<Transaction> Transactions = new List<Transaction>
        {
            new Transaction 
            { 
                CustomerId = MockDataSource.Customers[0].Id,
                Amount = 200.00M, 
                Date = DateTime.Now.AddDays(-1), 
                Source = "RichBank", 
                Category = "Travel" 
            },
            new Transaction 
            { 
                CustomerId = MockDataSource.Customers[0].Id,
                Amount = 200.00M, 
                Date = DateTime.Now.AddDays(-1), 
                Source = "RichBank", 
                Category = "Food" 
            },
            new Transaction 
            { 
                CustomerId = MockDataSource.Customers[1].Id,
                Amount = 150.00M, 
                Date = DateTime.Now.AddDays(-2), 
                Source = "RichBank", 
                Category = "Dining" 
            },
            new Transaction 
            { 
                CustomerId = MockDataSource.Customers[2].Id,
                Amount = 300.00M, 
                Date = DateTime.Now.AddDays(-3), 
                Source = "RichBank", 
                Category = "Shopping" 
            }
        }; 
    }
}
