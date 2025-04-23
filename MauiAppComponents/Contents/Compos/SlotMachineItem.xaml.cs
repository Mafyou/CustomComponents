using CommunityToolkit.Mvvm.Messaging;
using MauiAppComponents.Contents.Compos.ViewModels;
using MauiAppComponents.Contents.Messages;

namespace MauiAppComponents.Contents.Compos;

public partial class SlotMachineItem : ContentView
{
    public static readonly BindableProperty SelectedSlotItemProperty =
       BindableProperty.Create(
           nameof(SelectedSlotItem),
           typeof(int),
           typeof(SlotMachineItem),
           defaultValue: -1,
           defaultBindingMode: BindingMode.TwoWay);

    public int SelectedSlotItem
    {
        get => (int)GetValue(SelectedSlotItemProperty);
        set => SetValue(SelectedSlotItemProperty, value);
    }

    public SlotMachineItem()
    {
        InitializeComponent();

        WeakReferenceMessenger.Default.Register<ResetIndex>(this, (r, m) =>
        {
            SlotCollectionView.ScrollTo(0, animate: true);
        });
    }

    protected override void OnParentSet()
    {
        base.OnParentSet();

        BindingContext = new SlotMachineItemViewModel(SelectedSlotItem);
    }

    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        if (BindingContext is not SlotMachineItemViewModel vm) return;

        // Update the SelectedSlotItem based on the center item index
        int centerIndex = e.CenterItemIndex;
        vm.SetSelectedItem(centerIndex);
    }
}