using MauiAppComponents.ViewModels;
using System.ComponentModel;

namespace MauiAppComponents;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

    protected override void OnAppearing()
    {
        if (BindingContext is not MainPageViewModel vm) return;

        vm.OnAppearing();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

    }
}
