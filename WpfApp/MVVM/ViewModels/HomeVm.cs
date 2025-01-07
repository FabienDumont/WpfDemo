using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;

namespace WpfApp.MVVM.ViewModels;

public class HomeVm : BaseVm
{
  public ICommand NavigateModalSpinnerCommand { get; set; }
  public ICommand NavigateAnotherCommand { get; set; }

  public HomeVm(INavigationService anotherNavigationService, INavigationService spinnerNavigationService)
  {
    NavigateAnotherCommand = new RelayCommand(_ => { anotherNavigationService.Navigate(); });
    NavigateModalSpinnerCommand = new RelayCommand(_ => { spinnerNavigationService.Navigate(); });
  }
}
