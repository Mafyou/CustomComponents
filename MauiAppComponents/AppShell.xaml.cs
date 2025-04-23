namespace MauiAppComponents;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Preferences.Remove("History");
    }
}
