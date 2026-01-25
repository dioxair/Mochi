using System;

namespace Mochi.Domain;

public class AppConfig
{
    public string PetName { get; set; } = string.Empty;
    public Difficulty Difficulty { get; set; } = Difficulty.Normal;
    public Personality Personality { get; set; } = Personality.Chill;
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}