using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace WpfApp.Presentation.MVVM.ViewModels;

public class InformationVm(StringStore stringStore, INavigationService closeNavigationService) : BaseVm
{
  #region Properties

  public string? Message { get; } = stringStore.CurrentString;

  #endregion

  #region Commands

  public ICommand ReturnCommand { get; } = new NavigateCommand(closeNavigationService);

  #endregion
}
