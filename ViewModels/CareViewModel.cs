using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mochi.Domain;
using Mochi.Services;

namespace Mochi.ViewModels;

public partial class CareViewModel : ViewModelBase
{
    private readonly AppConfig _config;
    private readonly SaveData _save;
    private readonly AppStateService _appState;

    [ObservableProperty] private PetState _petState;

    [ObservableProperty] private string _lastActionMessage = "Choose an action to care for your pet!";

    public string PetName => _config.PetName;

    public CareViewModel(AppConfig config, SaveData save, AppStateService appState)
    {
        _config = config;
        _save = save;
        _appState = appState;
        _petState = save.Pet;
    }

    /// <summary>Design-time constructor.</summary>
    public CareViewModel() : this(new AppConfig { PetName = "Designer" }, SaveData.CreateDefault(), new AppStateService())
    {
    }

    [RelayCommand]
    private void Feed()
    {
        LastActionMessage = $"You fed {PetName}!";
    }

    [RelayCommand]
    private void Play()
    {
        LastActionMessage = $"You played with {PetName}!";
    }

    [RelayCommand]
    private void Sleep()
    {
        LastActionMessage = $"{PetName} is resting...";
    }

    [RelayCommand]
    private void Clean()
    {
        LastActionMessage = $"{PetName} is all clean!";
    }
}
