using System.Text.Json;
using System.Text.Json.Serialization;

namespace BudgetLogger.Models;

public class Transaction
 {
     public Transaction(decimal amount, string category, string description, DateTime dateTime, TransactionType type)
     {
         Amount = amount;
         Category = category;
         Description = description;
         DateTime = dateTime;
         Type = type;
     }

     [JsonPropertyName("amt")]
     [JsonRequired]
     public decimal Amount { get; set; }
     
     [JsonPropertyName("cat")]
     [JsonRequired]
     public string Category { get; set; }
     
     [JsonPropertyName("desc")]
     [JsonRequired]
     public string Description { get; set; }
     
     [JsonPropertyName("datetime")]
     [JsonRequired]
     public DateTime DateTime { get; set; }
     
     [JsonPropertyName("type")]
     [JsonRequired]
     public TransactionType Type { get; set; }
     
     [JsonIgnore]
     public DateTime Date => DateTime.Date;

     [JsonIgnore]
     public TimeSpan Time => DateTime.TimeOfDay;
 
     public override string ToString() => JsonSerializer.Serialize<Transaction>(this);
 }

public enum TransactionType
{
    Expense,
    Income
}


