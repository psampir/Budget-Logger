using BudgetLogger.Models;
using BudgetLogger.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BudgetLogger.Pages;

// Inherits from base class for models in Razor Pages
public class SummaryModel(ILogger<SummaryModel> logger, JsonFileTransactionService transactionService) : PageModel
{
    public JsonFileTransactionService TransactionService = transactionService;
    public List<Transaction>? Transactions { get; private set; } //value can only be changed by OnGet()
    
    // Calculates the total balance from all transactions
    public decimal GetBalance()
    {
        var balance = (
            from transaction in Transactions
            select transaction.Amount).Sum();

        return balance;
    }

    // Calculates the balance within a specific date range
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
    
    // Retrieves positive and negative categories with their respective total amounts within a specified date range
    public (Dictionary<string, decimal>, Dictionary<string, decimal>) GetCategories(DateTime startDate,
        DateTime endDate)
    {
        if (endDate < startDate)
        {
            (startDate, endDate) = (endDate, startDate);
        }

        // Groups transactions by category and calculates total amounts for each category within the date range
        var categoriesWithAmountsInRange = (
            from transaction in Transactions
            where transaction.Date >= startDate && transaction.Date <= endDate
            group transaction by transaction.Category
            into groupedTransactions
            select new
            {
                Category = groupedTransactions.Key,
                TotalAmount = groupedTransactions.Sum(transaction => transaction.Amount)
            }
        ).ToDictionary(item => item.Category, item => item.TotalAmount);

        // Filters positive categories and orders them by descending total amounts
        var positiveCategories = (
            from category in categoriesWithAmountsInRange
            where category.Value > 0
            orderby category.Value descending
            select category
        ).ToDictionary(category => category.Key, category => category.Value);

        // Filters negative categories and orders them by ascending total amounts
        var negativeCategories = (
            from category in categoriesWithAmountsInRange
            where category.Value < 0
            orderby category.Value
            select category
        ).ToDictionary(category => category.Key, category => category.Value);

        return (positiveCategories, negativeCategories);
    }
    
    // Retrieves transactions when the page is accessed
    public void OnGet()
    {
        Transactions = TransactionService.GetTransactions();
    }

}