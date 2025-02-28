using System;
using System.Collections.Generic;

namespace WpfApp.Presentation.Services;

internal static class NavigationPageKeys
{
  #region Fields

  public static readonly IDictionary<string, Uri> Pages = new Dictionary<string, Uri>
  {
    {
      "HomePage",
      new Uri("pack://application:,,,/Views/HomePage.xaml", UriKind.Absolute)
    },
    {
      "AnotherPage",
      new Uri("pack://application:,,,/Views/AnotherPage.xaml", UriKind.Absolute)
    },
    {
      "ModalPage",
      new Uri("pack://application:,,,/Views/ModalView.xaml", UriKind.Absolute)
    }
  };

  #endregion
}
