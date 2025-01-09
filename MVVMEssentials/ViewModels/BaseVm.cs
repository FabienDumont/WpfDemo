using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMEssentials.ViewModels;

public class BaseVm : INotifyPropertyChanged
{
  protected bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
  {
    if (EqualityComparer<T>.Default.Equals(field, value))
      return false;

    field = value;
    OnPropertyChanged(propertyName);
    return true;
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  protected void OnPropertyChanged([CallerMemberName] string? name = null)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
  }

  public virtual void Dispose()
  {
  }
}
