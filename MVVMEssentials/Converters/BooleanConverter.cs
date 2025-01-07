using System.Globalization;
using System.Windows.Data;

namespace MVVMEssentials.Converters;

public class BooleanConverter<T>(T trueValue, T falseValue) : IValueConverter
{
  public T True { get; set; } = trueValue;
  public T False { get; set; } = falseValue;

  public virtual object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
  {
    return value is true ? True : False;
  }

  public virtual object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
  {
    return value is T value1 && EqualityComparer<T>.Default.Equals(value1, True);
  }
}
