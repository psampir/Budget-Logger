using System.Text.Json;
using System.Text.Json.Serialization;

namespace BudgetLogger.Models;

public class Transaction(decimal amount, string category, string description, DateTime dateTime)
{
    [JsonPropertyName("amt")]
     [JsonRequired]
     public decimal Amount { get; set; } = amount;

     [JsonPropertyName("cat")]
     [JsonRequired]
     public string Category { get; set; } = category;

     [JsonPropertyName("desc")]
     [JsonRequired]
     public string Description { get; set; } = description;

     [JsonPropertyName("datetime")]
     [JsonRequired]
     public DateTime DateTime { get; set; } = dateTime;
     
     [JsonIgnore]
     public DateTime Date => DateTime.Date;

     [JsonIgnore]
     public TimeSpan Time => DateTime.TimeOfDay;
 
     public override string ToString() => JsonSerializer.Serialize<Transaction>(this);
 }

