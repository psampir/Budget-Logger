// Importing necessary namespaces
using System.Text.Json;
using BudgetLogger.Models;

namespace BudgetLogger.Services
{
    // Service for handling transactions stored in a JSON file
    public class JsonFileTransactionService(IWebHostEnvironment webHostEnvironment) // Primary constructor that injects the hosting environment into the service
    {
        private IWebHostEnvironment WebHostEnvironment { get; } = webHostEnvironment; // Hosting environment
        
        // Property to get the full path to the transactions JSON file
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "transactions.json");

        // Method to retrieve transactions from the JSON file
        public List<Transaction>? GetTransactions()
        {
            // Using statement to open and read the JSON file
            using var jsonFileReader = File.OpenText(JsonFileName);

            // Deserializing the JSON content into a list of Transaction objects
            return JsonSerializer.Deserialize<List<Transaction>?>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Option to make property name matching case-insensitive during deserialization
                });
        }
        
        public void DeleteTransaction(decimal amount, string category, string description, DateTime datetime)
        {
            // Read existing transactions from the JSON file
            var transactions = GetTransactions() ?? new List<Transaction>();

            // Find and remove the transaction with the specified amount, category, description and datetime
            var transactionToRemove = (
                from transaction in transactions
                where transaction.Amount == amount && transaction.Category == category && transaction.Description == description && transaction.DateTime == datetime
                select transaction
            ).FirstOrDefault();

            // 
            if (transactionToRemove == null) return;
            
            // Remove selected transaction
            transactions.Remove(transactionToRemove);

            // Serialize the updated list of transactions to JSON
            var jsonString = JsonSerializer.Serialize(transactions);

            // Write the updated JSON content back to the file
            File.WriteAllText(JsonFileName, jsonString);
        }
    }
}