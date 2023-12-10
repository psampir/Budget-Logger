using System.Text.Json;
using System.Transactions;

namespace BudgetLogger.Services;

public class JsonFileTransactionService(IWebHostEnvironment webHostEnvironment)
{
    public IWebHostEnvironment WebHostEnvironment { get; } = webHostEnvironment;

    private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "transactions.json");

    public IEnumerable<Transaction>? GetProducts()
    {
        using var jsonFileReader = File.OpenText(JsonFileName);
        return JsonSerializer.Deserialize<Transaction[]>(jsonFileReader.ReadToEnd(),
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
    }
}