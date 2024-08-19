using System.IO.Compression;
using Beacon.WorkspaceTests;

[TestName("Extension Test")]
[TestDescription("Validates that the workspace only contains files with allowed extensions.")]
class ExtensionWorkspaceTest : WorkspaceTest {
  private readonly string[] allowedExtensions = [".cs", ".java", ".py"];

  public override bool validate(TestContext context) {
    foreach (ZipArchiveEntry entry in context.zipArchive.Entries) {
      if (!allowedExtensions.Contains(Path.GetExtension(entry.FullName))) return false;
    }

    return true;
  }
}