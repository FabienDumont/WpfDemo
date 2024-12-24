using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;

namespace WpfApp.MVVM.ViewModels;

public class LoadingSpinnerDemoVm(INavigationService closeNavigationService) : BaseVm
{
	public ICommand ReturnCommand { get; } = new NavigateCommand(closeNavigationService);
}
