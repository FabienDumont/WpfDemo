using System.Windows.Input;
using MVVMEssentials.ViewModels;

namespace MVVMEssentials.Commands;

public delegate ICommand CreateCommand<in TVm>(TVm vm) where TVm : BaseVm;
