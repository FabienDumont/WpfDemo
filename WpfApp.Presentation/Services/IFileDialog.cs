using System.Threading.Tasks;

namespace WpfApp.Presentation.Services;

public interface IFileDialog
{
  #region Methods

  /// <summary>
  ///   Opens the retailer file asynchronous.
  /// </summary>
  /// <param name="filter">The filter.</param>
  /// <returns></returns>
  Task<OpenFileDialogResult> OpenLoadFileAsync(string filter);

  #endregion
}
