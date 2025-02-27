using System;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Presentation.Controls;

namespace WpfApp.Presentation.Services;

public class DialogService : IDialogService
{
  #region Methods

  public static bool ShowToast(string message, DialogImage image)
  {
    var toast = new ToastMessageBox {Message = message, Image = image};
    toast.Show();
    return true;
  }

  #endregion

  #region Implementation of IDialogService

  public async Task ShowWarning(string message)
  {
    await Task.FromResult(ShowToast(message, DialogImage.Warning)).ConfigureAwait(false);
  }

  public async Task ShowError(string message)
  {
    await Task.FromResult(ShowToast(message, DialogImage.Error)).ConfigureAwait(false);
  }

  public async Task ShowError(Exception error)
  {
    var message = error.Message;
    var innerException = error.InnerException;

    while (innerException != null)
    {
      message += (string.IsNullOrEmpty(innerException.Message) ? string.Empty : innerException.Message);

      innerException = innerException.InnerException;
    }

    await Task.FromResult(ShowToast(message, DialogImage.Error)).ConfigureAwait(false);
  }

  public async Task ShowMessage(string message)
  {
    await Task.FromResult(ShowToast(message, DialogImage.Information)).ConfigureAwait(false);
  }

  public async Task ShowMessage(string message, Action afterHideCallback)
  {
    await Task.FromResult(ShowToast(message, DialogImage.Information)).ConfigureAwait(false);
  }

  public Task<bool> ShowMessage(
    string message, string title
  )
  {
    return Task.FromResult(
      System.Windows.Application.Current.MainWindow != null && MessageBox.Show(
        System.Windows.Application.Current.MainWindow, message, title, MessageBoxButton.YesNo, MessageBoxImage.Question,
        MessageBoxResult.Yes
      ) == MessageBoxResult.Yes
    );
  }

  public async Task ShowMessageBox(string message)
  {
    await Task.FromResult(ShowToast(message, DialogImage.Information)).ConfigureAwait(false);
  }

  #endregion
}
