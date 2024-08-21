using System.IO;
using System.Linq;

namespace WorkspaceTests;

[TestName("Extension")]
[TestDescription("Validates that the workspace only contains files with allowed extensions.")]
internal class ExtensionWorkspaceTest : WorkspaceTest {
  private static readonly string[] commonExtensions = {
    ".txt", ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".csv", ".xml", ".json", ".zip", ".rar", ".7z",
    ".md", ".yml", ".yaml", ".ini", ".cfg", ".config", ".log", ".gitignore", ".gitattributes"
  };

  private static readonly string[] javasScriptExtensions = {
    ".js", ".jsx", ".ts", ".tsx", ".mjs", ".cjs", ".html", ".css", ".scss", ".less", ".map", ".lock", ".babelrc",
    ".eslintrc", ".prettierrc", ".npmrc", ".nvmrc", ".yarnrc", ".tsconfig.json", ".package.json", ".package-lock.json"
  };

  private static readonly string[] cSharpExtensions = {
    ".cs", ".csx", ".vb", ".razor", ".cshtml", ".csproj", ".sln", ".resx", ".config", ".settings", ".xaml", ".asax",
    ".ashx", ".aspx", ".master", ".sitemap", ".browserconfig", ".pubxml", ".targets", ".props", ".nuspec", ".nupkg",
    ".snk", ".pfx", ".editorconfig"
  };

  protected override bool validate(TestContext context) {
    var illegalExtensions = context.zipArchive.entries.Where(entry => {
      var extension = Path.GetExtension(entry.FullName);
      // todo: replace with project specific option for allowed extensions
      var allowedExtensions = cSharpExtensions.Concat(commonExtensions).Distinct().ToArray();
      if (allowedExtensions.Contains(extension)) return false;
      this.addWarning($"Entry {entry.FullName} uses illegal extension {extension}.");
      return true;
    });

    return illegalExtensions.Any();
  }
}