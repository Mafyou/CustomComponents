using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppComponents.Contents.Compos.ViewModels;
using MauiAppComponents.Contents.Messages;
using System.Collections.ObjectModel;
using System.Text;

namespace MauiAppComponents.Contents.Compos;

public partial class SlotsMachine : ContentView
{
    public ObservableCollection<SlotMachineItem> Items { get; set; } = [];
    public SlotsMachine()
    {
        InitializeComponent();
        BindingContext = this;
    }

    [RelayCommand]
    private void OnHowMuchClicked(object? sender)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < Items.Count; i++)
        {
            var slotValue = Preferences.Get($"Slot_{i}", 0);
            sb.Append(slotValue);
        }
        if (int.TryParse($"{sb}", out var result))
            MainThread.BeginInvokeOnMainThread(() =>
                App.Current!.Windows[0].Page!.DisplayAlert("Casino", $"{result}", "Ok")
            );
        WeakReferenceMessenger.Default.Send(new ResetIndex());
    }

    [RelayCommand]
    private void OnHowManyClicked(object? sender)
    {
        if (sender is not string s) return;
        if (string.IsNullOrEmpty(s))
        {
            MainThread.BeginInvokeOnMainThread(() =>
                App.Current!.Windows[0].Page!.DisplayAlert("Casino", "Please enter a number", "Ok")
            );
            return;
        }
        if (!int.TryParse(s, out var number) || number < 1)
        {
            MainThread.BeginInvokeOnMainThread(() =>
                App.Current!.Windows[0].Page!.DisplayAlert("Casino", "Please enter a valid number greater than 0", "Ok")
            );
            return;
        }
        if (number <= 0)
        {
            MainThread.BeginInvokeOnMainThread(() =>
                App.Current!.Windows[0].Page!.DisplayAlert("Casino", "Please enter a number less than or equal to 0", "Ok")
            );
            return;
        }
        Items.Clear();
        for (int i = 0; i < number; i++)
        {
            Items.Add(new SlotMachineItem
            {
                SelectedSlotItem = i,
                BindingContext = new SlotMachineItemViewModel(i)
            });
        }
        OnPropertyChanged(nameof(Items));
    }
}