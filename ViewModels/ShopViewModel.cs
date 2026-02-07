using CommunityToolkit.Mvvm.ComponentModel;

namespace Mochi.ViewModels;

public partial class ShopViewModel : ViewModelBase
{
    [ObservableProperty] private int _walletBalance = 100;

    [ObservableProperty] private string _statusMessage = "Shop coming soon!";
}
