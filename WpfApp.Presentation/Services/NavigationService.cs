using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace WpfApp.Presentation.Services;

public class NavigationService : INavigationService
{
  #region Fields

  private static readonly IDictionary<string, object> Parameters = new Dictionary<string, object>();

  #endregion

  #region Properties

  private Frame? Frame =>
    field ??= System.Windows.Application.Current.MainWindow?.FindChildren<Frame>().FirstOrDefault();

  public string? CurrentPageKey { get; private set; }

  #endregion

  #region Implementation of ILicenseNavigationService

  /// <summary>
  ///   Tries the get parameter.
  /// </summary>
  /// <typeparam name="T">The type of result.</typeparam>
  /// <param name="pageKey">The page key.</param>
  public T? TryGetParameter<T>(string pageKey)
  {
    return Parameters.TryGetValue(pageKey, out var parameter) && parameter is T p ? p : default;
  }

  /// <summary>
  ///   If possible, instructs the navigation service
  ///   to discard the current page and display the previous page
  ///   on the navigation stack.
  /// </summary>
  public void GoBack()
  {
    if (Parameters.ContainsKey(CurrentPageKey))
    {
      Parameters.Remove(CurrentPageKey);
    }

    Frame.NavigationService.GoBack();
  }

  /// <summary>
  ///   Instructs the navigation service to display a new page
  ///   corresponding to the given key. Depending on the platforms,
  ///   the navigation service might have to be configured with a
  ///   key/page list.
  /// </summary>
  /// <param name="pageKey">
  ///   The key corresponding to the page
  ///   that should be displayed.
  /// </param>
  public void NavigateTo(string pageKey)
  {
    NavigateTo(pageKey, null);
  }

  public void NavigateTo(string pageKey, object? parameter)
  {
    if (NavigationPageKeys.Pages.ContainsKey(pageKey))
    {
      if (parameter == null)
      {
        Frame.NavigationService.Navigate(NavigationPageKeys.Pages[pageKey]);
      }
      else
      {
        Frame.NavigationService.Navigate(NavigationPageKeys.Pages[pageKey], parameter); // Update key
        Parameters[pageKey] = parameter;
      }

      CurrentPageKey = pageKey;
    }
    else
    {
      throw new ArgumentOutOfRangeException(nameof(pageKey));
    }
  }

  #endregion
}
