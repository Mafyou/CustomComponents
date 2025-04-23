namespace MauiAppComponents.Contents.Compos;

public partial class CoffeeItem : ContentView
{
    public CoffeeItem()
    {
        InitializeComponent();
    }

    protected async override void OnParentSet()
    {
        while (true)
        {
            // Perform a shaking animation
            const int shakeDistance = 5; // Distance to move left and right
            const int shakeDuration = 50; // Duration of each shake step in milliseconds

            for (int i = 0; i < 5; i++) // Repeat the shake 5 times
            {
                await CoffeeImageButton.TranslateTo(-shakeDistance, 0, shakeDuration, easing: Easing.Linear);
                await CoffeeImageButton.TranslateTo(shakeDistance, 0, shakeDuration, easing: Easing.Linear);
            }

            // Reset position to ensure it ends at the original location
            await CoffeeImageButton.TranslateTo(0, 0, shakeDuration, easing: Easing.Linear);

            // Pause before the next shake
            await Task.Delay(TimeSpan.FromSeconds(2));
        }
    }
}