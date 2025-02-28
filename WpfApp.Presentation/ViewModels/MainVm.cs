using CommunityToolkit.Mvvm.Input;
using WpfApp.Presentation.Services;

namespace WpfApp.Presentation.ViewModels;

public sealed partial class MainVm : BaseVm
{
  #region Ctors

  public MainVm(IDialogService dialogService, INavigationService navigationService) : base(
    dialogService, navigationService
  )
  {
  }

  #endregion

  #region Methods

  [RelayCommand]
  private void Loading()
  {
    NavigationService.NavigateTo("HomePage");
  }

  #endregion
}
