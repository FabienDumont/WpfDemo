using System.IO;
using System.Threading;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfApp.Presentation.Services;
using WpfEssentials;
using WpfEssentials.Services;
using MainWindow = WpfApp.Presentation.Views.MainWindow;

namespace WpfApp.Presentation;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
  public static IHost? Host { get; set; }

  public App()
  {
    var hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder();
    hostBuilder.ConfigureHostConfiguration(
      configuration => configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json")
    );

    hostBuilder.ConfigureAppConfiguration((_, _) => ConfigureSettings());
    hostBuilder.ConfigureServices((_, services) => ConfigureServices(services));

    Host = hostBuilder.Build();
  }

  private void ConfigureSettings()
  {
  }

  private void ConfigureServices(IServiceCollection services)
  {
    // Adds services
    services.AddSingleton<MainWindow>();
    services.AddWpf();
    services.AddSingleton<IDialogService, DialogService>();
    services.AddSingleton<INavigationService, NavigationService>();

    ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());
  }

  protected override async void OnStartup(StartupEventArgs e)
  {
    if (Host != null)
    {
      await Host.StartAsync(CancellationToken.None).ConfigureAwait(true);
    }

    base.OnStartup(e);
  }

  protected override async void OnExit(ExitEventArgs e)
  {
    if (Host != null)
    {
      await Host.StopAsync(CancellationToken.None).ConfigureAwait(true);
    }

    base.OnExit(e);
  }
}
