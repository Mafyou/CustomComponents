using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppComponents.Contents.Popups;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiAppComponents.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<string> _history = [];

    public void OnAppearing()
    {
        var h = Preferences.Get("History", string.Empty);
        if (!string.IsNullOrEmpty(h))
        {
            var j = JsonSerializer.Deserialize<List<string>>(h)!;
            History = [.. j];
            History = [.. History.Reverse()];
        }
    }

    [RelayCommand]
    private async Task OnCloseClicked()
    {
        await App.Current!.Windows[0].Page!.ShowPopupAsync(new LastKeywordsPopup());
        OnAppearing();
    }
}