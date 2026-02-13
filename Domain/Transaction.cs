using System;

namespace Mochi.Domain;

public class Transaction
{
    public Transaction()
    {
    }

    public Transaction(int amount, bool isExpense, string category, string description)
    {
        TimestampUtc = DateTime.UtcNow;
        Amount = amount;
        IsExpense = isExpense;
        Category = category;
        Description = description;
    }

    public DateTime TimestampUtc { get; set; }
    public int Amount { get; set; }
    public bool IsExpense { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}