namespace MVVMEssentials.Commands;

public abstract class BaseAsyncCommand(Action<Exception>? exception = null) : BaseCommand
{
  private bool _isExecuting;

  private bool IsExecuting
  {
    get => _isExecuting;
    set
    {
      _isExecuting = value;
      OnCanExecuteChanged();
    }
  }

  public override bool CanExecute(object? parameter) => !IsExecuting && base.CanExecute(parameter);

  public override async void Execute(object? parameter)
  {
    IsExecuting = true;
    try
    {
      await ExecuteAsync(parameter);
    }
    catch (Exception ex)
    {
      exception?.Invoke(ex);
    }

    IsExecuting = false;
  }

  protected abstract Task ExecuteAsync(object? parameter);
}
