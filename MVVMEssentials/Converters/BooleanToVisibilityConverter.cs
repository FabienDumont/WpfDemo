using System.Windows;

namespace MVVMEssentials.Converters;

public sealed class BooleanToVisibilityConverter()
  : BooleanConverter<Visibility>(Visibility.Visible, Visibility.Collapsed);
