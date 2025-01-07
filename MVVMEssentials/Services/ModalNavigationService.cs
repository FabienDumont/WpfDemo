using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Services;

public class ModalNavigationService<TVm>(ModalNavigationStore navigationStore, Func<TVm> createViewModel)
  : INavigationService where TVm : BaseVm
{
  public void Navigate()
  {
    navigationStore.CurrentViewModel = createViewModel();
  }
}
