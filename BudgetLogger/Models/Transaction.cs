using System.Text.Json;
using System.Text.Json.Serialization;

namespace BudgetLogger.Models;

public class Transaction(decimal amount, string category, string description, DateTime dateTime)
{
    [JsonPropertyName("amt")]
     public decimal Amount { get; } = amount;

     [JsonPropertyName("cat")]
     public string Category { get; } = category;

     [JsonPropertyName("desc")]
     public string Description { get; } = description;

     [JsonPropertyName("datetime")]
     public DateTime DateTime { get; } = dateTime;
     
     [JsonIgnore]
     public DateTime Date => DateTime.Date;

     [JsonIgnore]
     public TimeSpan Time => DateTime.TimeOfDay;
 
     public override string ToString() => JsonSerializer.Serialize(this);
 }

