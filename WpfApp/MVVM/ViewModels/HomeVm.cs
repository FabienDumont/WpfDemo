﻿using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;

namespace WpfApp.MVVM.ViewModels;

public class HomeVm : BaseVm
{
  public ICommand NavigateModalSpinnerCommand { get; }
  public ICommand NavigateAnotherCommand { get; }

  public HomeVm(INavigationService anotherNavigationService, INavigationService spinnerNavigationService)
  {
    NavigateAnotherCommand = new RelayCommand(_ => { anotherNavigationService.Navigate(); });
    NavigateModalSpinnerCommand = new RelayCommand(_ => { spinnerNavigationService.Navigate(); });
  }
}
