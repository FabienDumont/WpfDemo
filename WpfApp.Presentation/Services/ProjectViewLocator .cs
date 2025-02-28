using System;
using System.Collections.Generic;
using WpfApp.Presentation.ViewModels;
using WpfApp.Presentation.Views;
using WpfEssentials.Services;

namespace WpfApp.Presentation.Services;

public class ProjectViewLocator : IViewLocator
{
  private static readonly Dictionary<Type, Type> ViewModelToViewMapping = new()
  {
    {typeof(ModalVm), typeof(ModalView)}
  };

  public Type? GetViewType(Type viewModelType)
  {
    return ViewModelToViewMapping.GetValueOrDefault(viewModelType);
  }
}
