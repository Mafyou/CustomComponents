using System.Globalization;

namespace MauiAppComponents.Contents.Compos.Converters;

internal class ThereAreItemsConveter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not IList<SlotMachineItem> Items) return false;
        return Items.Count > 0;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}