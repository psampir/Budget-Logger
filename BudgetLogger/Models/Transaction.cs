using System.Text.Json;
using System.Text.Json.Serialization;

namespace BudgetLogger.Models;

public class Transaction
{
    [JsonPropertyName("amt")]
    public decimal Amount { get; set; }
    [JsonPropertyName("cat")]
    public string Category { get; set; }
    [JsonPropertyName("desc")]
    public string Description { get; set; }
    public DateTime DateTime { get; set; }
    [JsonPropertyName("type")]
    public TransactionType Type { get; set; }

    public override string ToString() => JsonSerializer.Serialize<Transaction>(this);
}

public enum TransactionType
{
    Expense,
    Income
}


