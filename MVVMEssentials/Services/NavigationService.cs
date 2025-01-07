using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Services;

public class NavigationService<TVm>(INavigationStore navigationStore, CreateViewModel<TVm> createViewModel)
  : INavigationService where TVm : BaseVm
{
  public void Navigate() => navigationStore.CurrentViewModel = createViewModel();
}
