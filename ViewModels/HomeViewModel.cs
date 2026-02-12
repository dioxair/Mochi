using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Mochi.Domain;
using Mochi.Services;

namespace Mochi.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    [ObservableProperty] private string _petName;
    [ObservableProperty] private PetState _petState;
    [ObservableProperty] private string _speechBubbleText = "Hi there :D I'm so happy to see you!";

    public HomeViewModel(AppConfig config, SaveData save)
    {
        _petName = config.PetName;
        _petState = save.Pet;

        _petState.PropertyChanged += OnPetStatChanged;
        UpdateSpeechBubble();
    }

    /// <summary>Design-time constructor.</summary>
    public HomeViewModel() : this(new AppConfig { PetName = "Designer Pet" }, SaveData.CreateDefault())
    {
    }

    public string MoodDisplay => PetCareService.CalculateMood(PetState).ToString();

    private void OnPetStatChanged(object? sender, PropertyChangedEventArgs e)
    {
        OnPropertyChanged(nameof(MoodDisplay));
        UpdateSpeechBubble();
    }

    private void UpdateSpeechBubble()
    {
        Mood mood = PetCareService.CalculateMood(PetState);
        SpeechBubbleText = mood switch
        {
            Mood.Ecstatic => "I'm having the best day ever!! :D",
            Mood.Happy => "Life is good! Thanks for taking care of me :)",
            Mood.Content => "I'm doing alright.",
            Mood.Sad => "I could use some attention... :(",
            Mood.Miserable => "Please help me... I don't feel good.",
            Mood.Sleeping => "Zzz...",
            _ => "..."
        };
    }
}