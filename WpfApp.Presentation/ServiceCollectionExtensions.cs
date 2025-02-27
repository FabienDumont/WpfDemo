using Microsoft.Extensions.DependencyInjection;
using TextRpg.Presentation.MVVM.ViewModels;
using WpfApp.Presentation.MVVM.ViewModels;

namespace TextRpg.Presentation;

public static class ServiceCollectionExtensions
{
  #region Methods

  public static IServiceCollection AddWpf(this IServiceCollection services)
  {
    services.AddSingleton<MainVm>().AddSingleton<HomeVm>().AddSingleton<AnotherVm>().AddSingleton<ModalVm>();
    return services;
  }

  #endregion
}
