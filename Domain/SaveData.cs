using System;
using System.Collections.Generic;

namespace Mochi.Domain;

public class SaveData
{
    public DateTime LastOpenedUtc { get; set; } = DateTime.UtcNow;
    public PetState Pet { get; set; } = new();
    public List<HistoryEntry> History { get; set; } = [];
    public int WalletBalance { get; set; }
    public List<Transaction> Transactions { get; set; } = [];
    public List<ActiveBuff> ActiveBuffs { get; set; } = [];

    public static SaveData CreateDefault()
    {
        SaveData save = new()
        {
            LastOpenedUtc = DateTime.UtcNow,
            WalletBalance = 50,
            Pet = new PetState
            {
                Hunger = 20,
                Energy = 80,
                Happiness = 70,
                IsAsleep = false
            },
            History = [new HistoryEntry("New pet created")]
        };
        return save;
    }
}