using TransactionAggregationApi.Models;
using TransactionAggregationApi.Data;

namespace TransactionAggregationApi.Services;

// Combine data from multiple banks
public class TransactionService
{
    // Combine all transactions from all 3 banks
    private IEnumerable<Transaction> allTransactions =>
     MockDataSource.Transactions
        .Concat(BrokeBankData.Transactions)
        .Concat(RichBankData.Transactions)
        .Concat(WealthyBankData.Transactions);

    public IEnumerable<Transaction> getAllTransactions() =>
        allTransactions  //get all transactions
        .OrderByDescending(t => t.Date);

    public IEnumerable<Transaction> getTransactionsByCustomer(Guid customerId) =>
        allTransactions.Where(t => t.CustomerId == customerId);  //filter by customerId

    public IEnumerable<object> getAggregatedCategory() //will sort the transactions by category
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


    public IEnumerable<object> getAggregatedSourceByMonth() //will sort the transactions by source,year and month in descending order
    {
        return allTransactions
        .GroupBy(t => new { t.Source, t.Date.Year, t.Date.Month })
        .Select(g => new
        {
            g.Key.Source,
            g.Key.Year,
            g.Key.Month,
            TotalAmount = g.Sum(t => t.Amount),
            Count = g.Count()
        })
        .OrderByDescending(x => x.Year)
        .ThenByDescending(x => x.Month)
        .ToList();
    }


    public object getMoneyIn()
    {
        var moneyInTransactions = allTransactions.Where(t => t.isMoneyIn); //when isMoneyIn is true
        return new
        {
            TotalAmount = moneyInTransactions.Sum(t => t.Amount),
            Count = moneyInTransactions.Count(),
            Transactions = moneyInTransactions
        };
    }

    public object getMoneyOut()
    {
        var moneyOutTransactions = allTransactions.Where(t => !t.isMoneyIn); //when isMoneyIn is false
        return new
        {
            TotalAmount = moneyOutTransactions.Sum(t => t.Amount),
            Count = moneyOutTransactions.Count(),
            Transactions = moneyOutTransactions
        };
    }


}
