using System;
using System.Globalization;
using MiAppGastos.Models;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MiAppGastos.Converters;

public class AmountColorConverter : IValueConverter
{
#pragma warning disable CA1416
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is TransactionType type)
        {
#if IOS || MACCATALYST
            return type == TransactionType.Ingreso ? Colors.Green : Colors.Red;
#else
            return type == TransactionType.Ingreso ? Color.FromArgb("008000") : Color.FromArgb("FF0000");
#endif
        }
#if IOS || MACCATALYST
        return Colors.Black;
#else
        return Color.FromArgb("000000");
#endif
    }
#pragma warning restore CA1416

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}