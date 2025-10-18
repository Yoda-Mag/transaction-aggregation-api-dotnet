using TransactionAggregationApi.Models;
using TransactionAggregationApi.Data;

namespace TransactionAggregationApi.Services;

// Combine data from multiple banks
public class TransactionService
{
    // Combine all transactions from both banks
    private IEnumerable<Transaction> AllTransactions =>
        RichBankData.Transactions
        .Concat(WealthyBankData.Transactions); 

    public IEnumerable<Transaction> GetAllTransactions() => AllTransactions;

    public IEnumerable<Transaction> GetTransactionsByCustomer(Guid customerId) =>
        AllTransactions.Where(t => t.CustomerId == customerId);

    public IEnumerable<object> GetAggregatedCategory()
    {
        return AllTransactions
            .GroupBy(t => t.Category)
            .Select(g => new
            {
                Category = g.Key,
                TotalAmount = g.Sum(t => t.Amount),
                Count = g.Count()
            });
    }

    public IEnumerable<object> GetAggregatedSource()
    {
        return AllTransactions
            .GroupBy(t => new { t.Date.Year, t.Date.Month })
            .Select(g => new
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                TotalAmount = g.Sum(t => t.Amount),
                Count = g.Count()
            });
    }
}
