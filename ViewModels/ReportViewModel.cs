using System.Collections.Generic;
using System.Linq;
using Mochi.Domain;

namespace Mochi.ViewModels;

public class ReportViewModel : ViewModelBase
{
    public string PetName { get; }
    public Difficulty Difficulty { get; }
    public Personality Personality { get; }
    public string CreatedDate { get; }
    public IReadOnlyList<HistoryEntry> History { get; }

    public ReportViewModel(AppConfig config, SaveData save)
    {
        PetName = config.PetName;
        Difficulty = config.Difficulty;
        Personality = config.Personality;
        CreatedDate = config.CreatedUtc.ToLocalTime().ToString("MMMM d, yyyy");
        // Show newest entries first
        History = save.History.AsEnumerable().Reverse().ToList();
    }

    /// <summary>Design-time constructor.</summary>
    public ReportViewModel() : this(new AppConfig { PetName = "Designer" }, SaveData.CreateDefault())
    {
    }
}
