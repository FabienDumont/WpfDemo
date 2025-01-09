namespace MVVMEssentials.Commands;

public class RelayCommand<T>(Action<T> execute, Func<T, bool>? canExecute = null) : BaseCommand
{
  private readonly Action<T> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

  public override bool CanExecute(object? parameter)
  {
    if (parameter is T param)
    {
      return canExecute?.Invoke(param) ?? true;
    }

    // Allow default value for reference types
    if (parameter is null && typeof(T).IsClass)
    {
      return canExecute?.Invoke(default!) ?? true;
    }

    throw new ArgumentException($"Invalid parameter type. Expected {typeof(T).Name}.");
  }

  public override void Execute(object? parameter)
  {
    if (parameter is T param)
    {
      _execute(param);
    }
    else if (parameter is null && typeof(T).IsClass)
    {
      _execute(default!);
    }
    else
    {
      throw new ArgumentException($"Invalid parameter type. Expected {typeof(T).Name}.");
    }
  }
}

public class RelayCommand(Action execute, Func<bool>? canExecute = null) : BaseCommand
{
  private readonly Action _execute = execute ?? throw new ArgumentNullException(nameof(execute));

  public override bool CanExecute(object? parameter) => canExecute?.Invoke() ?? true;

  public override void Execute(object? parameter) => _execute();
}
