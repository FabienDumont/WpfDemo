using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace MVVMEssentials.Controls;

public class LoadingSpinner : Control
{
  public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register(
    nameof(IsLoading), typeof(bool), typeof(LoadingSpinner), new PropertyMetadata(false)
  );

  public bool IsLoading
  {
    get => (bool) GetValue(IsLoadingProperty);
    set => SetValue(IsLoadingProperty, value);
  }

  public static readonly DependencyProperty DiameterProperty = DependencyProperty.Register(
    nameof(Diameter), typeof(double), typeof(LoadingSpinner), new PropertyMetadata(100.0)
  );

  public double Diameter
  {
    get => (double) GetValue(DiameterProperty);
    set => SetValue(DiameterProperty, value);
  }

  public static readonly DependencyProperty ThicknessProperty = DependencyProperty.Register(
    nameof(Thickness), typeof(double), typeof(LoadingSpinner), new PropertyMetadata(1.0)
  );

  public double Thickness
  {
    get => (double) GetValue(ThicknessProperty);
    set => SetValue(ThicknessProperty, value);
  }

  public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
    nameof(Color), typeof(Brush), typeof(LoadingSpinner), new PropertyMetadata(Brushes.Black)
  );

  public Brush Color
  {
    get => (Brush) GetValue(ColorProperty);
    set => SetValue(ColorProperty, value);
  }

  public static readonly DependencyProperty CapProperty = DependencyProperty.Register(
    nameof(Cap), typeof(PenLineCap), typeof(LoadingSpinner), new PropertyMetadata(PenLineCap.Flat)
  );

  public PenLineCap Cap
  {
    get => (PenLineCap) GetValue(CapProperty);
    set => SetValue(CapProperty, value);
  }

  static LoadingSpinner()
  {
    DefaultStyleKeyProperty.OverrideMetadata(
      typeof(LoadingSpinner), new FrameworkPropertyMetadata(typeof(LoadingSpinner))
    );
  }
}

public class DiameterAndThicknessToStrokeDashArrayConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    if (values.Length < 2 || !double.TryParse(values[0].ToString(), out var diameter) ||
        !double.TryParse(values[1].ToString(), out var thickness))
    {
      return new DoubleCollection([0.0]);
    }

    var circumference = Math.PI * diameter;

    var lineLength = circumference * 0.75;
    var gapLength = circumference - lineLength;

    return new DoubleCollection([lineLength / thickness, gapLength / thickness]);
  }

  public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
