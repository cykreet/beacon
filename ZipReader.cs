using System.IO.Compression;
using System.Linq;

/*
  Middleman class for reading and managing opened zip file handles
  allowing for thread-safe access to zip file contents.
*/
internal class ZipReader {
  private readonly ZipArchive zipArchive;
  public readonly ZipArchiveEntry[] entries;
  public readonly bool isEncrypted;

  public ZipReader(string path) {
    zipArchive = ZipFile.OpenRead(path);
    // todo: somehow no longer a property after converting
    // isEncrypted = zipArchive.Entries.Any((entry) => entry.isEncrypted);
    isEncrypted = false;
    entries = [.. zipArchive.Entries];
  }
}