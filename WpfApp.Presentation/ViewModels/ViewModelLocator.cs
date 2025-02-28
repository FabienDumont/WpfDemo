using System.Diagnostics;
using WpfApp.Presentation.Services;

namespace WpfApp.Presentation.ViewModels;

[DebuggerNonUserCode]
public class ViewModelLocator
{
  public MainVm? MainVm => ServiceLocator.Current.GetInstance<MainVm>();
  public HomeVm? HomeVm => ServiceLocator.Current.GetInstance<HomeVm>();
  public AnotherVm? AnotherVm => ServiceLocator.Current.GetInstance<AnotherVm>();
  public ModalVm? ModalVm => ServiceLocator.Current.GetInstance<ModalVm>();
}
