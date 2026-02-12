using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Mochi.Domain;
using Mochi.Services;

namespace Mochi.ViewModels;

public partial class AppViewModel : ViewModelBase
{
    private readonly AppStateService _appState = new();

    [ObservableProperty] private ViewModelBase? _currentViewModel;

    public async Task InitializeAsync()
    {
        // 1. Ensure app folder exists (handled by AppStateService)
        // 2. Try load config
        AppConfig? config = await _appState.LoadConfigOrNullAsync();

        if (config == null)
        {
            // 3. If config missing then show FirstLaunch wizard
            FirstLaunchViewModel firstLaunchVm = new(_appState);
            firstLaunchVm.SetupCompleted += OnSetupCompleted;
            CurrentViewModel = firstLaunchVm;
        }
        else
        {
            // 4. If config exists then load save and show main view
            await NavigateToMainAsync();
        }
    }

    private async void OnSetupCompleted(object? sender, EventArgs e)
    {
        if (sender is FirstLaunchViewModel firstLaunchVm) firstLaunchVm.SetupCompleted -= OnSetupCompleted;

        await NavigateToMainAsync();
    }

    public async Task SaveOnShutdownAsync()
    {
        if (_appState.CurrentSave != null)
        {
            _appState.CurrentSave.LastOpenedUtc = DateTime.UtcNow;
            await _appState.SaveSaveAsync(_appState.CurrentSave);
        }
    }

    private async Task NavigateToMainAsync()
    {
        // Load save (will create default if missing, and handle time-away)
        SaveData save = await _appState.LoadSaveOrCreateDefaultAsync();
        AppConfig config = _appState.CurrentConfig!;

        CurrentViewModel = new MainViewModel(config, save, _appState);
    }
}