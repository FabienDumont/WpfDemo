﻿using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WpfEssentials;
using WpfEssentials.Services;

namespace WpfApp.Presentation.ViewModels;

public class HomeVm(IDialogService dialogService, INavigationService navigationService, ModalVm modalVm)
  : BaseVm(dialogService, navigationService)
{
  #region Commands

  public ICommand NavigateAnotherCommand => new RelayCommand(NavigateAnother);
  public ICommand NavigateModalCommand => new RelayCommand(NavigateModal);

  #endregion

  #region Methods

  private void NavigateAnother()
  {
    NavigationService.NavigateTo("AnotherPage");
  }

  private void NavigateModal()
  {
    DialogService.ShowDialog(modalVm);
  }

  #endregion
}
