using Waypoint;

namespace Beacon.WorkspaceTests;

[TestName("Encryption")]
[TestDescription("Check if any files in the workspace are encrypted.")]
internal class EncryptionWorkspaceTest : WorkspaceTest {
  protected override bool validate(TestContext context) {
    if (context.zipArchive.isEncrypted) return false;
    return true;
  }
}