using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Services;

public class ParameterNavigationService<TParameter, TVm>(
  NavigationStore navigationStore, CreateViewModel<TParameter, TVm> createViewModel
) where TVm : BaseVm
{
  public void Navigate(TParameter parameter) => navigationStore.CurrentViewModel = createViewModel(parameter);
}
