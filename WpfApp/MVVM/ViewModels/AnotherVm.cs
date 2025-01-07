using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace WpfApp.MVVM.ViewModels;

public class AnotherVm : BaseVm
{
  public string? InformationMessage
  {
    get;
    set
    {
      field = value;
      OnPropertyChanged();
    }
  }

  public ICommand NavigateHomeViewCommand { get; }
  public ICommand NavigateInformationViewCommand { get; }

  public AnotherVm(
    StringStore stringStore, INavigationService homeNavigationService, INavigationService informationNavigationService
  )
  {
    NavigateHomeViewCommand = new RelayCommand(_ => { homeNavigationService.Navigate(); });
    NavigateInformationViewCommand = new RelayCommand(
      _ =>
      {
        stringStore.CurrentString = InformationMessage;
        informationNavigationService.Navigate();
      }
    );
  }
}
