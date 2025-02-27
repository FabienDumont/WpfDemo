using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WpfApp.Presentation.Services;

public class FileDialog : IFileDialog
{
  #region Implementation of IFileDialog

  public Task<OpenFileDialogResult> OpenLoadFileAsync(string filter)
  {
    var fileDialog = new OpenFileDialog {Filter = filter, Multiselect = true};

    return Task.FromResult(
      fileDialog.ShowDialog(System.Windows.Application.Current.MainWindow) == true
        ? new OpenFileDialogResult(true, fileDialog.FileNames.Select(_ => new FileInfo(_)).ToList())
        : OpenFileDialogResult.Failed
    );
  }

  #endregion
}
