using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Mochi.Domain;

namespace Mochi.ViewModels;

public partial class ReportViewModel : ViewModelBase
{
    private readonly SaveData _save;

    [ObservableProperty] private IReadOnlyList<HistoryEntry> _history;
    [ObservableProperty] private IReadOnlyList<CategorySummary> _spendingByCategory;

    public ReportViewModel(AppConfig config, SaveData save)
    {
        _save = save;
        PetName = config.PetName;
        Difficulty = config.Difficulty;
        Personality = config.Personality;
        CreatedDate = config.CreatedUtc.ToLocalTime().ToString("MMMM d, yyyy");

        _history = save.History.AsEnumerable().Reverse().ToList();
        _spendingByCategory = ComputeSpendingByCategory();
    }

    /// <summary>Design-time constructor.</summary>
    public ReportViewModel() : this(new AppConfig { PetName = "Designer" }, SaveData.CreateDefault())
    {
    }

    public string PetName { get; }
    public Difficulty Difficulty { get; }
    public Personality Personality { get; }
    public string CreatedDate { get; }

    public int TotalEarned => _save.Transactions
        .Where(t => !t.IsExpense).Sum(t => t.Amount);

    public int TotalSpent => _save.Transactions
        .Where(t => t.IsExpense).Sum(t => t.Amount);

    public int CurrentBalance => _save.WalletBalance;

    public bool HasPurchases => _save.Transactions.Any(t => t.IsExpense);

    private IReadOnlyList<CategorySummary> ComputeSpendingByCategory()
    {
        return _save.Transactions
            .Where(t => t.IsExpense)
            .GroupBy(t => t.Category)
            .Select(g => new CategorySummary(g.Key, g.Sum(t => t.Amount)))
            .OrderByDescending(c => c.Total)
            .ToList();
    }

    public void Refresh()
    {
        History = _save.History.AsEnumerable().Reverse().ToList();
        SpendingByCategory = ComputeSpendingByCategory();
        OnPropertyChanged(nameof(TotalEarned));
        OnPropertyChanged(nameof(TotalSpent));
        OnPropertyChanged(nameof(CurrentBalance));
        OnPropertyChanged(nameof(HasPurchases));
    }
}