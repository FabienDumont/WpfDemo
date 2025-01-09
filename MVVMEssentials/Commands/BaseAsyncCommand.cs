using System.Windows.Input;

namespace MVVMEssentials.Commands;

public abstract class BaseAsyncCommand : ICommand
{
  public event EventHandler? CanExecuteChanged;

  private bool _isExecuting;

  protected bool IsExecuting
  {
    get => _isExecuting;
    private set
    {
      _isExecuting = value;
      OnCanExecuteChanged();
    }
  }

  public virtual bool CanExecute(object? parameter) => !IsExecuting;

  public async void Execute(object? parameter)
  {
    if (CanExecute(parameter))
    {
      IsExecuting = true;
      try
      {
        await ExecuteAsync(parameter);
      }
      finally
      {
        IsExecuting = false;
      }
    }
  }

  protected abstract Task ExecuteAsync(object? parameter);

  protected void OnCanExecuteChanged()
  {
    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
  }
}
