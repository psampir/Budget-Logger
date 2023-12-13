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
    
    // public IActionResult OnPost(string action, int id)
    // {
    //     if (action == "delete")
    //     {
            // Find and remove the transaction by ID
            // var transactionToDelete = Transactions.FirstOrDefault(t => t.Id == id);
            // if (transactionToDelete != null)
            // {
            //     Transactions.Remove(transactionToDelete);
                // TransactionService.DeleteTransaction();
                // Update the JSON file or database with the modified Transactions list
                // TransactionService.UpdateTransactions(Transactions);
//             }
//         }
//
//         return RedirectToPage("/Index"); // Redirect back to the page
//     }
}