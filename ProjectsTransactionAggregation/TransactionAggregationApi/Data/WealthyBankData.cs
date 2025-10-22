using TransactionAggregationApi.Models;
using TransactionAggregationApi.Data;

namespace TransactionAggregationApi.Data
{
    public static class WealthyBankData
    {

        public static List<Transaction> Transactions = new List<Transaction>
        {
                 new Transaction
                 { 
                    Id = Guid.NewGuid(),
                    CustomerId = MockDataSource.Customers[0].Id,
                     Amount = 200.00M, 
                     Date = DateTime.Now.AddDays(-1), 
                     Source = "WealthyBank", 
                     Category = "Travel" 
                },
                  new Transaction
                  { 
                    Id = Guid.NewGuid(),
                    CustomerId = MockDataSource.Customers[0].Id,
                     Amount = 200.00M, 
                     Date = DateTime.Now.AddDays(-1), 
                     Source = "WealthyBank", 
                     Category = "Travel" 
                },
                new Transaction
                { 
                    Id = Guid.NewGuid(),
                    CustomerId = MockDataSource.Customers[1].Id,
                        Amount = 150.00M, 
                        Date = DateTime.Now.AddDays(-2), 
                        Source = "WealthyBank", 
                        Category = "Dining" 
                },
                new Transaction
                { 
                    Id = Guid.NewGuid(),
                    CustomerId = MockDataSource.Customers[2].Id,
                        Amount = 300.00M, 
                        Date = DateTime.Now.AddDays(-3), 
                        Source = "WealthyBank", 
                        Category = "Shopping" 
                }

            
        };
    }
}