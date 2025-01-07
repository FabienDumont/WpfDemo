using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace WpfApp.MVVM.ViewModels;

public class InformationVm(StringStore stringStore, INavigationService closeNavigationService) : BaseVm
{
  public string? Message { get; } = stringStore.CurrentString;

  public ICommand ReturnCommand { get; } = new NavigateCommand(closeNavigationService);
}
