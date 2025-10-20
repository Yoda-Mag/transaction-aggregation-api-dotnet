using TransactionAggregationApi.Models;
using TransactionAggregationApi.Data;

namespace TransactionAggregationApi.Services;

// Combine data from multiple banks
public class TransactionService
{
    // Combine all transactions from both bank
    private IEnumerable<Transaction> allTransactions =>
        RichBankData.Transactions
        .Concat(WealthyBankData.Transactions); 

    public IEnumerable<Transaction> getAllTransactions() => allTransactions;

    public IEnumerable<Transaction> getTransactionsByCustomer(Guid customerId) =>
        allTransactions.Where(t => t.CustomerId == customerId);

    public IEnumerable<object> getAggregatedCategory()
    {
        return allTransactions
            .GroupBy(t => t.Category)
            .Select(g => new
            {
                Category = g.Key,
                TotalAmount = g.Sum(t => t.Amount),
                Count = g.Count()
            });
    }


    public IEnumerable<object> getAggregatedSource()
    {
        return allTransactions
            .GroupBy(t => new { t.Date.Year, t.Date.Month })
            .Select(g => new
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                TotalAmount = g.Sum(t => t.Amount),
                Count = g.Count()
            });
    }


            public object getMoneyIn()
        {
            var moneyInTransactions = allTransactions.Where(t => t.isMoneyIn);
            return new
            {
                TotalAmount = moneyInTransactions.Sum(t => t.Amount),
                Count = moneyInTransactions.Count(),
                Transactions = moneyInTransactions
            };
        }

        public object getMoneyOut()
        {
            var moneyOutTransactions = allTransactions.Where(t => !t.isMoneyIn);
            return new
            {
                TotalAmount = moneyOutTransactions.Sum(t => t.Amount),
                Count = moneyOutTransactions.Count(),
                Transactions = moneyOutTransactions
            };
        }


}
