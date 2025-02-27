using System.IO;
using System.Threading;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextRpg.Presentation;
using WpfApp.Presentation.MVVM.Views;
using WpfApp.Presentation.Services;

namespace WpfApp.Presentation;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
  public static IHost Host { get; set; }

  public App()
  {
    var hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder();
    hostBuilder.ConfigureHostConfiguration(
      configuration => configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json")
    );

    hostBuilder.ConfigureAppConfiguration((context, _) => ConfigureSettings(context.Configuration));
    hostBuilder.ConfigureServices((_, services) => ConfigureServices(services));

    Host = hostBuilder.Build();
  }

  private void ConfigureSettings(IConfiguration configuration)
  {
  }

  private void ConfigureServices(IServiceCollection services)
  {
    // Adds services
    services.AddSingleton<MainWindow>();
    services.AddWpf();
    services.AddSingleton<IFileDialog, FileDialog>();
    services.AddSingleton<IDialogService, DialogService>();
    services.AddSingleton<INavigationService, NavigationService>();

    ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());
  }

  protected override async void OnStartup(StartupEventArgs e)
  {
    await Host.StartAsync(CancellationToken.None).ConfigureAwait(true);
    base.OnStartup(e);
  }

  protected override async void OnExit(ExitEventArgs e)
  {
    await Host.StopAsync(CancellationToken.None).ConfigureAwait(true);
    base.OnExit(e);
  }
}
