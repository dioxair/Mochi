using System;

namespace Mochi.Domain;

public class HistoryEntry
{
    public HistoryEntry()
    {
    }

    public HistoryEntry(string message)
    {
        TimestampUtc = DateTime.UtcNow;
        Message = message;
    }

    public DateTime TimestampUtc { get; set; }
    public string Message { get; set; } = string.Empty;
}