using CommunityToolkit.Maui.Views;
using MauiAppComponents.Contents.Popups.ViewModels;

namespace MauiAppComponents.Contents.Popups;

public partial class LastKeywordsPopup : Popup
{
    public LastKeywordsPopup()
    {
        InitializeComponent();
        BindingContext = new LastKeywordsPopupViewModel();
    }

    protected override void OnParentSet()
    {
        base.OnParentSet();
        if (BindingContext is LastKeywordsPopupViewModel vm)
        {
            vm.OnAppearing();
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Close(true);
    }
}