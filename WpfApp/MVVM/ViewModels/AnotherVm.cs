using System.Collections.ObjectModel;
using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace WpfApp.MVVM.ViewModels;

public class AnotherVm : BaseVm
{
  #region Properties

  public string InformationMessage
  {
    get;
    set => Set(ref field, value);
  } = string.Empty;

  public string MessageToAdd
  {
    get;
    set => Set(ref field, value);
  } = string.Empty;

  public ObservableCollection<string> Messages { get; } = [];

  #endregion

  #region Commands

  public ICommand AddMessageCommand { get; }
  public ICommand NavigateHomeViewCommand { get; }
  public ICommand NavigateInformationViewCommand { get; }

  #endregion

  #region Ctors

  public AnotherVm(
    StringStore stringStore, INavigationService homeNavigationService, INavigationService informationNavigationService
  )
  {
    AddMessageCommand = new RelayCommand(
      _ =>
      {
        if (!string.IsNullOrWhiteSpace(MessageToAdd))
        {
          Messages.Add(MessageToAdd);
          MessageToAdd = string.Empty;
        }
      }
    );

    NavigateHomeViewCommand = new RelayCommand(_ => { homeNavigationService.Navigate(); });
    NavigateInformationViewCommand = new RelayCommand(
      _ =>
      {
        stringStore.CurrentString = InformationMessage;
        informationNavigationService.Navigate();
      }
    );
  }

  #endregion
}
