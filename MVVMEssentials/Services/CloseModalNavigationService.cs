using MVVMEssentials.Stores;

namespace MVVMEssentials.Services;

public class CloseModalNavigationService(ModalNavigationStore navigationStore) : INavigationService
{
  public void Navigate() => navigationStore.Close();
}
