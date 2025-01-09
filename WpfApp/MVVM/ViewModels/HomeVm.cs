﻿using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;

namespace WpfApp.MVVM.ViewModels;

public class HomeVm(INavigationService anotherNavigationService, INavigationService spinnerNavigationService) : BaseVm
{
  #region Commands

  public ICommand NavigateModalSpinnerCommand { get; } =
    new RelayCommand(_ => { spinnerNavigationService.Navigate(); });

  public ICommand NavigateAnotherCommand { get; } = new RelayCommand(_ => { anotherNavigationService.Navigate(); });

  #endregion
}
