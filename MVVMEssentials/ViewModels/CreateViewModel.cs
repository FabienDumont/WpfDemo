namespace MVVMEssentials.ViewModels;

public delegate TVm CreateViewModel<out TVm>() where TVm : BaseVm;

public delegate TVm CreateViewModel<in TParameter, out TVm>(TParameter parameter) where TVm : BaseVm;
