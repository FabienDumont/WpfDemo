using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MVVMEssentials.ContentControls;

public class Modal : ContentControl
{
  public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(
    nameof(IsOpen), typeof(bool), typeof(Modal), new PropertyMetadata(false)
  );

  public bool IsOpen
  {
    get => (bool) GetValue(IsOpenProperty);
    set => SetValue(IsOpenProperty, value);
  }

  static Modal()
  {
    DefaultStyleKeyProperty.OverrideMetadata(typeof(Modal), new FrameworkPropertyMetadata(typeof(Modal)));
    BackgroundProperty.OverrideMetadata(typeof(Modal), new FrameworkPropertyMetadata(CreateDefaultBackground()));
  }

  private static SolidColorBrush CreateDefaultBackground()
  {
    return new SolidColorBrush(Colors.Black) {Opacity = 0.3};
  }
}
