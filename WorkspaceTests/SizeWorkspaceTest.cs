using System.Linq;

namespace WorkspaceTests;

[TestName("Size")]
[TestDescription("Check if any files in the workspace is to large")]
internal class SizeWorkspaceTest : WorkspaceTest {
  private const long maxLeng = 64 * 1024 * 1024;

  protected override bool validate(TestContext context) =>
    // todo: check individual file sizes and warn about largest file sizes
    // ExtensionWorkspace test does something similar.
    context.zipArchive.entries.All(entry => entry.Length < maxLeng);
}