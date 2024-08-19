using System.IO.Compression;

/*
  Middleman class for reading and managing opened zip file handles
  allowing for thread-safe access to zip file contents.
*/
class ZipReader {
  private readonly ZipArchive zipArchive;
  public readonly ZipArchiveEntry[] entries;
  public readonly bool isEncrypted;

  public ZipReader(string path) {
    zipArchive = ZipFile.OpenRead(path);
    isEncrypted = zipArchive.Entries.Any(entry => entry.IsEncrypted);
    entries = [.. zipArchive.Entries];
  }
}