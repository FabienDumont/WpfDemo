using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;

namespace WpfApp.Presentation.MVVM.ViewModels;

public class SpinnerVm(INavigationService closeNavigationService) : BaseVm
{
  #region Commands

  public ICommand ReturnCommand { get; } = new NavigateCommand(closeNavigationService);

  #endregion
}
