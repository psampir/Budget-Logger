using System.Globalization;
using BudgetLogger.Models;
using BudgetLogger.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BudgetLogger.Pages;

// Inherits from base class for models in Razor Pages
public class IndexModel(JsonFileTransactionService transactionService) : PageModel
{
    public JsonFileTransactionService TransactionService = transactionService;
    public List<Transaction>? Transactions { get; private set; } //value can only be changed by OnGet()
    public List<Transaction>? SortedTransactions { get; private set; }

    // Retrieves transactions when the page is accessed and sorts them by date and time in descending order
    public void OnGet()
    {
        Transactions = TransactionService.GetTransactions();
        SortedTransactions = (
            from transaction in Transactions
            orderby transaction.DateTime descending
            select transaction
        ).ToList();
    }
    
    // Handles deleting a transaction based on specified parameters and redirects to the Index page
    public IActionResult OnPostDelete(decimal amount, string category, string description, DateTime datetime)
    {
        TransactionService.DeleteTransaction(amount, category, description, datetime);
        return RedirectToPage("Index");
    }
    
    // Handles adding a new transaction with specified parameters and redirects to the Index page
    public IActionResult OnPostAdd(decimal amount, string category, string description, string date, string time, string transactionType)
    {
        if (transactionType == "expense") amount *= -1;
        
        amount = Math.Truncate(amount * 100) / 100;
        
        var dateFormatted = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        var timeFormatted = DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);
        var datetime = dateFormatted.Add(timeFormatted.TimeOfDay);
        
        TransactionService.AddTransaction(amount, category, description, datetime);
        return RedirectToPage("Index");
    }
}