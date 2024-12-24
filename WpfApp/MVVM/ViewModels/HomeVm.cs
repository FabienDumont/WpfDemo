using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace WpfApp.MVVM.ViewModels;

public class HomeVm : BaseVm
{
  private ObservableCollection<WorkstationSelectionViewModel> _workstations = [];
  public ICommand LoadingSpinnerDemoCommand { get; set; }

  public ObservableCollection<WorkstationSelectionViewModel> Workstations
  {
    get => _workstations;
    set
    {
      if (Equals(value, _workstations))
      {
        return;
      }

      _workstations = value;
      OnPropertyChanged();
    }
  }

  public DataTable FakeDataSource { get; set; }

  public HomeVm(StringStore stringStore, INavigationService loadingSpinnerDemoNavigationService)
  {

    var collection = new ObservableCollection<WorkstationSelectionViewModel>();

    collection.Add(new WorkstationSelectionViewModel
    {
      Code = "WS1",
      Label = "Workstation 1"
    });

    collection.Add(new WorkstationSelectionViewModel
    {
      Code = "WS2",
      Label = "Workstation 2",
      IsChecked = true
    });

    Workstations = collection;

    LoadingSpinnerDemoCommand = new RelayCommand(
      _ => { loadingSpinnerDemoNavigationService.Navigate(); }
    );


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
    #region Fields

    private string _code;
    private string _label;
    private bool _isChecked;

    #endregion

    #region Properties

    public string Code
    {
      get => _code;
      set
      {
        _code = value;
        OnPropertyChanged();
      }
    }

    public string Label
    {
      get => _label;
      set
      {
        _label = value;
        OnPropertyChanged();
      }
    }

    public bool IsChecked
    {
      get => _isChecked;
      set
      {
        _isChecked = value;
        OnPropertyChanged();
      }
    }

    #endregion
  }
}