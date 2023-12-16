using BudgetLogger.Models;
using BudgetLogger.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BudgetLogger.Pages;

public class IndexModel(ILogger<IndexModel> logger,
        JsonFileTransactionService transactionService)
    : PageModel
{
    public JsonFileTransactionService TransactionService = transactionService;
    public List<Transaction>? Transactions { get; private set; }
    public List<Transaction>? SortedTransactions { get; private set; }


    public void OnGet()
    {
        Transactions = TransactionService.GetTransactions();
        SortedTransactions = (from transaction in Transactions
            orderby transaction.DateTime descending
            select transaction).ToList();
    }
    
    public IActionResult OnPostDelete(decimal amount, string category, string description, DateTime datetime)
    {
        TransactionService.DeleteTransaction(amount, category, description, datetime);
        return RedirectToPage("Index");
    }
}