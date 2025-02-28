using System.Linq;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WpfApp.Presentation.Services;

namespace WpfApp.Presentation.ViewModels;

public class ModalVm(IDialogService dialogService, INavigationService navigationService)
  : BaseVm(dialogService, navigationService)
{
  #region Commands

  public ICommand CloseCommand => new RelayCommand(Close);

  #endregion

  #region Methods

  private void Close()
  {
    Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.DataContext == this)?.Close();
  }

  #endregion
}
