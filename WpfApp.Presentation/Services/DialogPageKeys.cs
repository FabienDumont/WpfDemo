using System;
using System.Collections.Generic;
using WpfApp.Presentation.ViewModels;
using WpfApp.Presentation.Views;

namespace WpfApp.Presentation.Services;

public static class DialogPageKeys
{
  private static readonly Dictionary<Type, Type> ViewModelToViewMapping = new()
  {
    {typeof(ModalVm), typeof(ModalView)}
  };

  public static Type GetViewType(Type viewModelType)
  {
    return ViewModelToViewMapping.TryGetValue(viewModelType, out var viewType) ? viewType : null!;
  }
}
