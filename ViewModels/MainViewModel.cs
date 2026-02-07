using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mochi.Domain;
using Mochi.Services;

namespace Mochi.ViewModels;

/// <summary>
/// Shell ViewModel that owns bottom-tab navigation and all child page ViewModels.
/// </summary>
public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsHomeSelected))]
    [NotifyPropertyChangedFor(nameof(IsCareSelected))]
    [NotifyPropertyChangedFor(nameof(IsShopSelected))]
    [NotifyPropertyChangedFor(nameof(IsReportSelected))]
    [NotifyPropertyChangedFor(nameof(IsHelpSelected))]
    private ViewModelBase _currentPage;

    public HomeViewModel HomeVm { get; }
    public CareViewModel CareVm { get; }
    public ShopViewModel ShopVm { get; }
    public ReportViewModel ReportVm { get; }
    public HelpViewModel HelpVm { get; }

    public bool IsHomeSelected => CurrentPage == HomeVm;
    public bool IsCareSelected => CurrentPage == CareVm;
    public bool IsShopSelected => CurrentPage == ShopVm;
    public bool IsReportSelected => CurrentPage == ReportVm;
    public bool IsHelpSelected => CurrentPage == HelpVm;

    public MainViewModel(AppConfig config, SaveData save, AppStateService appState)
    {
        HomeVm = new HomeViewModel(config, save);
        CareVm = new CareViewModel(config, save, appState);
        ShopVm = new ShopViewModel();
        ReportVm = new ReportViewModel(config, save);
        HelpVm = new HelpViewModel();

        _currentPage = HomeVm;
    }

    /// <summary>Design-time constructor.</summary>
    public MainViewModel() : this(
        new AppConfig { PetName = "Designer" },
        SaveData.CreateDefault(),
        new AppStateService())
    {
    }

    [RelayCommand]
    private void NavigateHome() => CurrentPage = HomeVm;

    [RelayCommand]
    private void NavigateCare() => CurrentPage = CareVm;

    [RelayCommand]
    private void NavigateShop() => CurrentPage = ShopVm;

    [RelayCommand]
    private void NavigateReport() => CurrentPage = ReportVm;

    [RelayCommand]
    private void NavigateHelp() => CurrentPage = HelpVm;
}