namespace MVVMEssentials.Services;

public class CompositeNavigationService(params INavigationService[] navigationServices) : INavigationService
{
  private readonly IEnumerable<INavigationService> _navigationServices = navigationServices;

  public void Navigate()
  {
    foreach (var navigationService in _navigationServices) navigationService.Navigate();
  }
}
