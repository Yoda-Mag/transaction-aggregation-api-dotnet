using TransactionAggregationApi.Models;

namespace TransactionAggregationApi.Data
{
    public static class WealthyBankData
    {
        public static List<Transaction> Transactions = GenerateTransactions();

        private static List<Transaction> GenerateTransactions()
        {
            var transactions = new List<Transaction>();
            var random = new Random();
            string[] categories = { "Travel", "Food", "Dining", "Shopping", "Entertainment", "Bills" };
            string source = "WealthyBank";

            // Loop through each customer
            foreach (var customer in MockDataSource.Customers)
            {
                // Generate 50 transactions per customer
                for (int i = 0; i < 50; i++)
                {
                    bool isMoneyIn = random.Next(3) != 0; //  2/3 chance for money-in

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
