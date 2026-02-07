using CommunityToolkit.Mvvm.ComponentModel;
using Mochi.Domain;

namespace Mochi.ViewModels;

public partial class HomeViewModel(AppConfig config, SaveData save) : ViewModelBase
{
    [ObservableProperty] private string _petName = config.PetName;

    [ObservableProperty] private PetState _petState = save.Pet;

    [ObservableProperty] private string _speechBubbleText = "Hi there :D I'm so happy to see you!";

    /// <summary>Design-time constructor.</summary>
    public HomeViewModel() : this(new AppConfig { PetName = "Designer Pet" }, SaveData.CreateDefault())
    {
    }

    public string MoodDisplay => DeriveMood();

    private string DeriveMood()
    {
        // Interpret hunger inversely (lower hunger = better) when averaging wellness.
        double avg = (PetState.Energy + PetState.Happiness + (100 - PetState.Hunger)) / 3.0;
        if (PetState.IsAsleep) return "Sleeping";
        if (avg >= 70) return "Happy";
        if (avg >= 40) return "Okay";
        return "Sad";
    }
}