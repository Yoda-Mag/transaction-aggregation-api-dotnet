using TransactionAggregationApi.Models;
using TransactionAggregationApi.Data;

namespace TransactionAggregationApi.Data
{
    public static class RichBankData
    {
        public static List<Transaction> Transactions = GenerateTransactions();

        private static List<Transaction> GenerateTransactions()
        {
            var transactions = new List<Transaction>();
            var random = new Random();
            string[] categories = { "Travel", "Food", "Dining", "Shopping", "Entertainment", "Bills" };
            string source = "RichBank";

            // Loop through each customer
            foreach (var customer in MockDataSource.Customers)
            {
                // Generate 20 transactions per customer
                for (int i = 0; i < 20; i++)
                {
                    bool isMoneyIn = random.Next(2) == 0; // Randomly assign money-in or money-out

                    transactions.Add(new Transaction
                    {
                        Id = Guid.NewGuid(),
                        CustomerId = customer.Id,
                        Amount = Math.Round((decimal)(random.NextDouble() * 1000 + 50), 2), // Random amount between 50 and 1050
                        Date = DateTime.Now.AddDays(-random.Next(0, 365)), // Random date in the past year
                        Source = source,
                        Category = categories[random.Next(categories.Length)],
                        isMoneyIn = isMoneyIn
                    });
                }
            }

            return transactions;
        }
    }
}
