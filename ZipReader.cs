using System.IO.Compression;

/*
  Middleman class for reading and managing opened zip file handles
  allowing for thread-safe access to zip file contents.
*/
public class ZipReader {
  public readonly ZipArchiveEntry[] entries;
  public readonly bool isEncrypted;
  private readonly ZipArchive zipArchive;

  public ZipReader(string path) {
    this.zipArchive = ZipFile.OpenRead(path);
    // todo: somehow no longer a property after converting
    // isEncrypted = zipArchive.Entries.Any((entry) => entry.isEncrypted);
    this.isEncrypted = false;
    this.entries = [.. this.zipArchive.Entries];
  }
}