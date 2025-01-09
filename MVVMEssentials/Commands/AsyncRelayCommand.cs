namespace MVVMEssentials.Commands;

public class AsyncRelayCommand<T>(Func<T, Task> execute, Func<T, bool>? canExecute = null) : BaseAsyncCommand
{
  private readonly Func<T, Task> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

  public override bool CanExecute(object? parameter)
  {
    if (parameter is T param)
    {
      return !IsExecuting && (canExecute?.Invoke(param) ?? true);
    }

    // Allow default value for reference types
    if (parameter is null && typeof(T).IsClass)
    {
      return !IsExecuting && (canExecute?.Invoke(default!) ?? true);
    }

    throw new ArgumentException($"Invalid parameter type. Expected {typeof(T).Name}.");
  }

  protected override Task ExecuteAsync(object? parameter)
  {
    if (parameter is T param)
    {
      return _execute(param);
    }
    else if (parameter is null && typeof(T).IsClass)
    {
      return _execute(default!);
    }

    throw new ArgumentException($"Invalid parameter type. Expected {typeof(T).Name}.");
  }
}

public class AsyncRelayCommand : BaseAsyncCommand
{
  private readonly Func<Task> _execute;
  private readonly Func<bool>? _canExecute;

  public AsyncRelayCommand(Func<Task> execute, Func<bool>? canExecute = null)
  {
    _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    _canExecute = canExecute;
  }

  public override bool CanExecute(object? parameter) => !IsExecuting && (_canExecute?.Invoke() ?? true);

  protected override Task ExecuteAsync(object? parameter) => _execute();
}
