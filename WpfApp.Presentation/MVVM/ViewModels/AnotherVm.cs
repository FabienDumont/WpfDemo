using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace WpfApp.Presentation.MVVM.ViewModels;

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

  public AsyncRelayCommand LoadDataCommand => new(LoadDataAsync, CanLoadData);
  public RelayCommand AddMessageCommand => new(AddMessage, CanAddMessage);
  public RelayCommand<object> AddSpecificMessageCommand => new(AddSpecificMessage, CanAddSpecificMessage);
  public ICommand NavigateHomeViewCommand { get; }
  public ICommand NavigateInformationViewCommand { get; }

  #endregion

  #region Ctors

  public AnotherVm(
    StringStore stringStore, INavigationService homeNavigationService, INavigationService informationNavigationService
  )
  {
    NavigateHomeViewCommand = new RelayCommand(homeNavigationService.Navigate);
    NavigateInformationViewCommand = new RelayCommand(
      () =>
      {
        stringStore.CurrentString = InformationMessage;
        informationNavigationService.Navigate();
      }
    );
  }

  #endregion

  #region Methods

  private async Task LoadDataAsync()
  {
    await Task.Delay(1000);
    Console.WriteLine("Data loaded!");
  }

  private bool CanLoadData() => true;

  private bool CanAddMessage()
  {
    return Messages.Count < 10;
  }

  private void AddMessage()
  {
    if (!string.IsNullOrWhiteSpace(MessageToAdd))
    {
      Messages.Add(MessageToAdd);
      MessageToAdd = string.Empty;
    }
  }

  private bool CanAddSpecificMessage(object? arg)
  {
    return Messages.Count < 10;
  }

  private void AddSpecificMessage(object? parameter)
  {
    if (parameter is string message)
    {
      Messages.Add(message);
    }
  }

  #endregion
}
