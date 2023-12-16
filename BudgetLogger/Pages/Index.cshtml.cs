using BudgetLogger.Models;
using BudgetLogger.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BudgetLogger.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public JsonFileTransactionService TransactionService;
    public List<Transaction>? Transactions { get; private set; }
    public List<Transaction>? SortedTransactions { get; private set; }


    public IndexModel(
        ILogger<IndexModel> logger, 
        JsonFileTransactionService transactionService)
    {
        _logger = logger;
        TransactionService = transactionService;
    }

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