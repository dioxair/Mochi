using CommunityToolkit.Mvvm.ComponentModel;

namespace Mochi.Domain;

public partial class PetState : ObservableObject
{
    [ObservableProperty] private int _energy = 80;
    [ObservableProperty] private int _happiness = 70;
    [ObservableProperty] private int _hunger = 20;
    [ObservableProperty] private bool _isAsleep;
}