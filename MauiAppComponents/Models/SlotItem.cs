using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAppComponents.Models;

public partial class SlotItem : ObservableObject
{
    [ObservableProperty]
    private int _valuePicked;
}