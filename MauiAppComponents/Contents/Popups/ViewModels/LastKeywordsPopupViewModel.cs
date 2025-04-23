using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiAppComponents.Contents.Popups.ViewModels;

public partial class LastKeywordsPopupViewModel : ObservableObject
{
    private List<string> _allKeywords = [];
    [ObservableProperty]
    private string _entryText = string.Empty;
    [ObservableProperty]
    private ObservableCollection<string> _keywords = [];

    public void OnAppearing()
    {
        var h = Preferences.Get("History", string.Empty);
        if (!string.IsNullOrEmpty(h))
        {
            _allKeywords = JsonSerializer.Deserialize<List<string>>(h)!;
            if (_allKeywords.Count > 3)
            {
                List<string> dist = [.. _allKeywords.Distinct()];
                Keywords = [.. dist[^3..]];
            }
            else
            {
                List<string> dist = [.. _allKeywords.Distinct()];
                dist.Reverse();
                Keywords = [.. dist];
            }
        }
        OnPropertyChanged(nameof(Keywords));
    }

    [RelayCommand]
    private void OnCloseClicked()
    {
        if (string.IsNullOrEmpty(EntryText)) return;

        _allKeywords.Add(EntryText);
        Preferences.Set("History", JsonSerializer.Serialize(_allKeywords));
    }

    [RelayCommand]
    private void OnKeywordClicked(string keyword)
    {
        if (string.IsNullOrEmpty(keyword)) return;
        EntryText = keyword;
    }
}