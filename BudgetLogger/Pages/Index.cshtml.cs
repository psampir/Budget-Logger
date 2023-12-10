using BudgetLogger.Models;
using BudgetLogger.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BudgetLogger.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public JsonFileTransactionService TransactionService;
    public IEnumerable<Transaction>? Transactions { get; private set; }

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
    }
}