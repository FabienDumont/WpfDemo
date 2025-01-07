using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;

namespace WpfApp.MVVM.ViewModels;

public class AnotherVm : BaseVm
{
  public ICommand NavigateHomeViewCommand { get; set; }

  public AnotherVm(INavigationService homeNavigationService)
  {
    NavigateHomeViewCommand = new RelayCommand(_ => { homeNavigationService.Navigate(); });
  }
}
