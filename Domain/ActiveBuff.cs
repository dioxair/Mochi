using System;

namespace Mochi.Domain;

public class ActiveBuff
{
    public ActiveBuff()
    {
    }

    public ActiveBuff(string itemName, DateTime expiresUtc,
        double hungerDecayMult, double energyDecayMult, double happinessDecayMult)
    {
        ItemName = itemName;
        ExpiresUtc = expiresUtc;
        HungerDecayMult = hungerDecayMult;
        EnergyDecayMult = energyDecayMult;
        HappinessDecayMult = happinessDecayMult;
    }

    public string ItemName { get; set; } = string.Empty;
    public DateTime ExpiresUtc { get; set; }
    public double HungerDecayMult { get; set; } = 1.0;
    public double EnergyDecayMult { get; set; } = 1.0;
    public double HappinessDecayMult { get; set; } = 1.0;
}