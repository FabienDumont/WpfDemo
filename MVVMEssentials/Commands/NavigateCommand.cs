using MVVMEssentials.Services;

namespace MVVMEssentials.Commands;

public class NavigateCommand(INavigationService navigationService) : BaseCommand
{
  public override void Execute(object? parameter) => navigationService.Navigate();
}
