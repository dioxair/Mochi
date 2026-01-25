using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Mochi.Domain;

namespace Mochi.ViewModels;

public partial class MainViewModel(AppConfig config, SaveData save) : ViewModelBase
{
    [ObservableProperty] private DateTime _createdUtc = config.CreatedUtc;

    [ObservableProperty] private Difficulty _difficulty = config.Difficulty;

    [ObservableProperty] private DateTime _lastOpenedUtc = save.LastOpenedUtc;

    [ObservableProperty] private Personality _personality = config.Personality;

    [ObservableProperty] private string _petName = config.PetName;

    [ObservableProperty] private PetState _petState = save.Pet;

    public MainViewModel() : this(new AppConfig { PetName = "Designer Pet" }, SaveData.CreateDefault())
    {
    }

    public string ConfigSummary => $"Pet: {PetName} | Difficulty: {Difficulty} | Personality: {Personality}";

    public string LastOpenedDisplay => $"Last opened: {LastOpenedUtc:g} UTC";

    public string PetStatusDisplay =>
        $"Hunger: {PetState.Hunger}/100 | Energy: {PetState.Energy}/100 | Happiness: {PetState.Happiness}/100 | Asleep: {PetState.IsAsleep}";
}