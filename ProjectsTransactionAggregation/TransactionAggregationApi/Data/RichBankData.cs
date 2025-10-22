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
                Id = Guid.NewGuid(),
                CustomerId = MockDataSource.Customers[0].Id,
                Amount = 200.00M,
                Date = DateTime.Now.AddDays(-1000),
                Source = "RichBank",
                Category = "Travel",
                isMoneyIn = false
            },
            new Transaction 
            { 
                Id = Guid.NewGuid(),
                CustomerId = MockDataSource.Customers[0].Id,
                Amount = 200.00M, 
                Date = DateTime.Now.AddDays(-1), 
                Source = "RichBank", 
                Category = "Bursary" ,
                isMoneyIn = true
            },
            new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerId = MockDataSource.Customers[1].Id,
                Amount = 150.00M,
                Date = DateTime.Now.AddDays(-2),
                Source = "RichBank",
                Category = "Dining" ,
                isMoneyIn  = false
            },
            new Transaction
            { 
                Id = Guid.NewGuid(),
                CustomerId = MockDataSource.Customers[2].Id,
                Amount = 300.00M, 
                Date = DateTime.Now.AddDays(-3), 
                Source = "RichBank", 
                Category = "Shopping", 
                isMoneyIn  = false
            }
        }; 
    }
}
