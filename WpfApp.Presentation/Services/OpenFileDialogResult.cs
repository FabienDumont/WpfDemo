using System.Collections.Generic;
using System.IO;

namespace WpfApp.Presentation.Services;

public class OpenFileDialogResult
{
  #region Ctors

  public OpenFileDialogResult(bool success, List<FileInfo>? file)
  {
    Success = success;
    File = file;
  }

  #endregion

  #region Properties

  public bool Success { get; }
  public List<FileInfo>? File { get; }
  public static OpenFileDialogResult Failed => new(false, null);

  #endregion
}
