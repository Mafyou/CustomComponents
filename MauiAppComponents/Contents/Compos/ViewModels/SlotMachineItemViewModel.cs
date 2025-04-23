using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppComponents.Models;
using System.Collections.ObjectModel;

namespace MauiAppComponents.Contents.Compos.ViewModels;

public partial class SlotMachineItemViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<SlotItem> _slotItems = [];

    [ObservableProperty]
    private int _selectedSlotItem;

    public SlotMachineItemViewModel(int initialSelectedItem)
    {
        SelectedSlotItem = initialSelectedItem;

        // Initialize the collection with dummy data
        SlotItems = [.. Enumerable.Range(0, 10).Select(i => new SlotItem { ValuePicked = i })];
    }

    public void SetSelectedItem(int index)
    {
        if (index >= 0 && index < SlotItems.Count)
        {
            Preferences.Set($"Slot_{SelectedSlotItem}", index);
        }
    }
}