using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WpfApp.Presentation.Services;

namespace WpfApp.Presentation.MVVM.ViewModels;

public class ModalVm(IDialogService dialogService, INavigationService navigationService)
  : BaseVm(dialogService, navigationService)
{
  #region Commands

  public ICommand NavigateBackCommand => new RelayCommand(NavigateBack);

  #endregion

  #region Methods

  private void NavigateBack()
  {
    NavigationService.GoBack();
  }

  #endregion
}
