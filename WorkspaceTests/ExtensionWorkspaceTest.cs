using System.IO.Compression;
using Beacon.WorkspaceTests;

[TestName("Extension")]
[TestDescription("Validates that the workspace only contains files with allowed extensions.")]
class ExtensionWorkspaceTest : WorkspaceTest {
  private readonly string[] allowedExtensions = [".cs", ".js", ".html", ".css", ".json", ".xml", ".txt", ".csproj", ".sln", ".gitignore"];

  public override bool validate(TestContext context) {
    foreach (ZipArchiveEntry entry in context.zipArchive.entries) {
      if (!allowedExtensions.Contains(Path.GetExtension(entry.FullName))) return false;
    }

    return true;
  }
}