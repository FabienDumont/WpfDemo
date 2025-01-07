using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using WpfApp.MVVM.ViewModels;
using WpfApp.MVVM.Views;

namespace WpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
  private readonly IHost _host;

  public App()
  {
    _host = Host.CreateDefaultBuilder().ConfigureAppConfiguration(
      c =>
      {
        c.AddJsonFile("appsettings.json");
        c.AddEnvironmentVariables();
      }
    ).ConfigureServices(
      (_, services) =>
      {
        // Store classes to send information through ViewModels
        services.AddSingleton<NavigationStore>();
        services.AddSingleton<ModalNavigationStore>();

        services.AddSingleton<StringStore>();

        services.AddSingleton<CloseModalNavigationService>();

        // Register all ViewModels
        services.AddTransient<HomeVm>(
          s => new HomeVm(s.GetRequiredService<NavigationService<AnotherVm>>(), CreateSpinnerNavigationService(s))
        );

        services.AddTransient<AnotherVm>(
          s => new AnotherVm(
            s.GetRequiredService<StringStore>(), s.GetRequiredService<NavigationService<HomeVm>>(),
            CreateInformationNavigationService(s)
          )
        );

        services.AddTransient(s => new SpinnerVm(s.GetRequiredService<CloseModalNavigationService>()));

        services.AddTransient(
          s => new InformationVm(
            s.GetRequiredService<StringStore>(), s.GetRequiredService<CloseModalNavigationService>()
          )
        );

        // Register all navigation services

        services.AddSingleton(
          s => new NavigationService<HomeVm>(s.GetRequiredService<NavigationStore>(), s.GetRequiredService<HomeVm>)
        );

        services.AddSingleton(
          s => new NavigationService<AnotherVm>(
            s.GetRequiredService<NavigationStore>(), s.GetRequiredService<AnotherVm>
          )
        );

        // Creation of the Main Window which can display the User Controls
        services.AddSingleton<MainVm>();

        services.AddSingleton(s => new MainWindow {DataContext = s.GetRequiredService<MainVm>()});
      }
    ).Build();
  }

  protected override void OnStartup(StartupEventArgs e)
  {
    _host.Start();

    var mainNavigationService = _host.Services.GetRequiredService<NavigationService<HomeVm>>();
    mainNavigationService.Navigate();

    // Showing the main Window
    MainWindow = _host.Services.GetRequiredService<MainWindow>();
    MainWindow.Show();

    base.OnStartup(e);
  }

  protected override void OnExit(ExitEventArgs e)
  {
    _host.Dispose();
    base.OnExit(e);
  }

  private static ModalNavigationService<SpinnerVm> CreateSpinnerNavigationService(IServiceProvider serviceProvider)
  {
    return new ModalNavigationService<SpinnerVm>(
      serviceProvider.GetRequiredService<ModalNavigationStore>(), serviceProvider.GetRequiredService<SpinnerVm>
    );
  }

  private static ModalNavigationService<InformationVm> CreateInformationNavigationService(IServiceProvider serviceProvider)
  {
    return new ModalNavigationService<InformationVm>(
      serviceProvider.GetRequiredService<ModalNavigationStore>(), serviceProvider.GetRequiredService<InformationVm>
    );
  }
}
