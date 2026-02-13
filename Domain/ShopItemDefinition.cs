namespace Mochi.Domain;

public record ShopItemDefinition(
    string Name,
    int Price,
    string Category,
    int DurationDays,
    double HungerDecayMult,
    double EnergyDecayMult,
    double HappinessDecayMult
);