using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MVVMEssentials.Converters;

public class EmptyEnumerableVisibilityConverter : IValueConverter
{
  public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
  {
    if (value is null)
    {
      return Visibility.Collapsed;
    }

    var enumerable = (IEnumerable) value;
    var count = enumerable.Cast<object?>().Count();

    return count > 0 ? Visibility.Visible : Visibility.Collapsed;
  }

  public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
