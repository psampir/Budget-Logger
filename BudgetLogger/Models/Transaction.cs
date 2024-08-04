using System.Text.Json;
using System.Text.Json.Serialization;

namespace BudgetLogger.Models;

// Represents a transaction entity with specific properties
public class Transaction(decimal amount, string category, string description, DateTime dateTime) // .NET 8 primary constructor
{
    [JsonPropertyName("amt")] // Serialized property names for JSON output
     public decimal Amount { get; } = amount;

     [JsonPropertyName("cat")]
     public string Category { get; } = category;

     [JsonPropertyName("desc")]
     public string Description { get; } = description;

     [JsonPropertyName("datetime")]
     public DateTime DateTime { get; } = dateTime;
     
     [JsonIgnore] // Ignores serialization for Date and Time properties
     public DateTime Date => DateTime.Date;

     [JsonIgnore]
     public TimeSpan Time => DateTime.TimeOfDay;
 
     // Returns a JSON string representation of the Transaction object
     public override string ToString() => JsonSerializer.Serialize(this);
 }


