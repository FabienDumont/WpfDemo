using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;

namespace WpfApp.MVVM.ViewModels;

public class HomeVm : BaseVm
{
  public ICommand LoadingSpinnerDemoCommand { get; set; }

  public ObservableCollection<WorkstationSelectionViewModel> Workstations
  {
    get;
    set
    {
      if (Equals(value, field))
      {
        return;
      }

      field = value;
      OnPropertyChanged();
    }
  }

  public DataTable FakeDataSource { get; }

  public HomeVm(INavigationService loadingSpinnerDemoNavigationService)
  {
    var collection = new ObservableCollection<WorkstationSelectionViewModel>
    {
      new()
      {
        Code = "WS1",
        Label = "Workstation 1"
      },
      new()
      {
        Code = "WS2",
        Label = "Workstation 2",
        IsChecked = true
      }
    };

    Workstations = collection;

    LoadingSpinnerDemoCommand = new RelayCommand(_ => { loadingSpinnerDemoNavigationService.Navigate(); });

    FakeDataSource = new DataTable(("Fake"));
    FakeDataSource.Columns.Add("Code produit");
    FakeDataSource.Columns.Add("Libellé produit");
    var row = FakeDataSource.NewRow();
    row["Code produit"] = "ENT1J1";
    row["Libellé produit"] = "Entrée 1J ADULTE";
    FakeDataSource.Rows.Add(row);

    var row2 = FakeDataSource.NewRow();
    row2["Code produit"] = "ENT2J1";
    row2["Libellé produit"] = "Entrée 2J ENFANT";
    FakeDataSource.Rows.Add(row2);
  }

  /// <summary>
  ///   WorkstationSelectionViewModel
  /// </summary>
  public class WorkstationSelectionViewModel : BaseVm
  {
    #region Properties

    public string? Code
    {
      get;
      set
      {
        field = value;
        OnPropertyChanged();
      }
    }

    public string? Label
    {
      get;
      set
      {
        field = value;
        OnPropertyChanged();
      }
    }

    public bool IsChecked
    {
      get;
      set
      {
        field = value;
        OnPropertyChanged();
      }
    }

    #endregion
  }
}
