using System.IO;
using System.IO.Compression;
using System.Linq;

namespace WorkspaceTests;

[TestName("Extension")]
[TestDescription("Validates that the workspace only contains files with allowed extensions.")]
internal class ExtensionWorkspaceTest : WorkspaceTest {
  private readonly string[] allowedExtensions = [".cs", ".js", ".html", ".css", ".json", ".xml", ".txt", ".csproj", ".sln", ".gitignore"];

  protected override bool validate(TestContext context) {
    return context.zipArchive.entries.All((entry) => allowedExtensions.Contains(Path.GetExtension(entry.FullName)));
  }
}