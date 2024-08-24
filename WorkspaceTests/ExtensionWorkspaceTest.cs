using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Beacon.WorkspaceTests;

[TestName("Extension")]
[TestDescription("Validates that the workspace only contains files with allowed extensions.")]
internal class ExtensionWorkspaceTest : WorkspaceTest {
  private static readonly string[] commonExtensions = [
    ".txt", ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".csv", ".xml", ".json", ".zip", ".rar", ".7z",
    ".md", ".yml", ".yaml", ".ini", ".cfg", ".config", ".log", ".gitignore", ".gitattributes"
  ];

  [AppliedWorkspace(WorkspaceType.Javascript)]
  private static readonly string[] javaScriptExtensions = [
    ".js", ".jsx", ".ts", ".tsx", ".mjs", ".cjs", ".html", ".css", ".scss", ".less", ".map", ".lock", ".babelrc",
    ".eslintrc", ".prettierrc", ".npmrc", ".nvmrc", ".yarnrc", ".tsconfig.json", ".package.json", ".package-lock.json"
  ];

  [AppliedWorkspace(WorkspaceType.CSharp)]
  private static readonly string[] cSharpExtensions = [
    ".cs", ".csx", ".vb", ".razor", ".cshtml", ".csproj", ".sln", ".resx", ".config", ".settings", ".xaml", ".asax",
    ".ashx", ".aspx", ".master", ".sitemap", ".browserconfig", ".pubxml", ".targets", ".props", ".nuspec", ".nupkg",
    ".snk", ".pfx", ".editorconfig"
  ];

  protected override bool validate(TestContext context) {
    var workspaceExtensions = this.getFieldsForWorkspace(context, javaScriptExtensions, cSharpExtensions);
    var allowedExtensions = workspaceExtensions.First().Concat(commonExtensions).Distinct().ToArray();
    var illegalExtensions = context.zipArchive.entries.Where(entry =>
      this.testEntry(allowedExtensions, entry));

    return illegalExtensions.Any() == false;
  }

  private bool testEntry(string[] allowedExtensions, ZipArchiveEntry entry) {
    var extension = Path.GetExtension(entry.FullName);
    if (allowedExtensions.Contains(extension)) return false;
    this.addWarning($"Entry {entry.FullName} uses illegal extension {extension}.");
    return true;
  }
}