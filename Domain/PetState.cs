namespace Mochi.Domain;

public class PetState
{
    public int Hunger { get; set; } = 20;
    public int Energy { get; set; } = 80;
    public int Happiness { get; set; } = 70;
    public bool IsAsleep { get; set; } = false;
}