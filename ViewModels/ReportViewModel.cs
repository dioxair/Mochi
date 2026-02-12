using System.Collections.Generic;
using System.Linq;
using Mochi.Domain;

namespace Mochi.ViewModels;

public class ReportViewModel(AppConfig config, SaveData save) : ViewModelBase
{
    // Show newest entries first

    /// <summary>Design-time constructor.</summary>
    public ReportViewModel() : this(new AppConfig { PetName = "Designer" }, SaveData.CreateDefault())
    {
    }

    public string PetName { get; } = config.PetName;
    public Difficulty Difficulty { get; } = config.Difficulty;
    public Personality Personality { get; } = config.Personality;
    public string CreatedDate { get; } = config.CreatedUtc.ToLocalTime().ToString("MMMM d, yyyy");
    public IReadOnlyList<HistoryEntry> History { get; } = save.History.AsEnumerable().Reverse().ToList();
}