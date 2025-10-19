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
    

    public object getMoneyFlowAggregate()
{
    var totalIn = allTransactions
        .Where(t => t.isMoneyIn)
        .Sum(t => t.Amount);

    var totalOut = allTransactions
        .Where(t => !t.isMoneyIn)
        .Sum(t => t.Amount);

    return new
    {
        TotalMoneyIn = totalIn,
        TotalMoneyOut = totalOut,
        NetFlow = totalIn - totalOut 
    };
}

}
