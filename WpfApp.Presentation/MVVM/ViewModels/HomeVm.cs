using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WpfApp.Presentation.Services;

namespace WpfApp.Presentation.MVVM.ViewModels;

public class HomeVm(IDialogService dialogService, INavigationService navigationService)
  : BaseVm(dialogService, navigationService)
{
  #region Commands

  public ICommand NavigateAnotherCommand => new RelayCommand(NavigateAnother);
  public ICommand NavigateModalCommand => new RelayCommand(NavigateModal);

  #endregion

  #region Methods

  private void NavigateAnother()
  {
    NavigationService.NavigateTo("AnotherPage");
  }

  private void NavigateModal()
  {
    NavigationService.NavigateTo("ModalPage");
  }

  #endregion
}
