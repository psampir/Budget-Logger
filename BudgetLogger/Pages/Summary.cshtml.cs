using BudgetLogger.Models;
using BudgetLogger.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BudgetLogger.Pages;

public class SummaryModel(ILogger<SummaryModel> logger,
        JsonFileTransactionService transactionService)
    : PageModel
{
    
    public JsonFileTransactionService TransactionService = transactionService;
    public List<Transaction>? Transactions { get; private set; }

    public decimal GetBalance()
    {
        var balance = (
            from transaction in Transactions
            select transaction.Amount).Sum();

        return balance;
    }

    public decimal GetBalance(DateTime startDate, DateTime endDate)
    {
        if (endDate < startDate)
        {
            (startDate, endDate) = (endDate, startDate);
        }
        
        var balanceInRange = (
            from transaction in Transactions
            where transaction.Date >= startDate && transaction.Date <= endDate
            select transaction.Amount).Sum();

        return balanceInRange;
    }
    
    public (Dictionary<string, decimal>, Dictionary<string, decimal>) GetCategories(DateTime startDate, DateTime endDate)
    {
        if (endDate < startDate)
        {
            (startDate, endDate) = (endDate, startDate);
        }

        var categoriesWithAmountsInRange = (Transactions!)
            .Where(transaction => transaction.Date >= startDate && transaction.Date <= endDate)
            .GroupBy(transaction => transaction.Category)
            .ToDictionary(
                group => group.Key,
                group => group.Sum(transaction => transaction.Amount)
            );
        
        var positiveCategories = categoriesWithAmountsInRange
            .Where(kv => kv.Value > 0)
            .OrderByDescending(kv => kv.Value) 
            .ToDictionary(kv => kv.Key, kv => kv.Value);

        var negativeCategories = categoriesWithAmountsInRange
            .Where(kv => kv.Value < 0)
            .OrderBy(kv => kv.Value)
            .ToDictionary(kv => kv.Key, kv => kv.Value);
        
        return (positiveCategories, negativeCategories);
    }

    public void OnGet()
    {
        Transactions = TransactionService.GetTransactions();
    }
    
}