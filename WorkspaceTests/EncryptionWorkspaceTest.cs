using System.IO.Compression;
using Beacon.WorkspaceTests;

[TestName("Encryption")]
[TestDescription("Check if any files in the workspace are encrypted.")]
class EncryptionWorkspaceTest : WorkspaceTest {
  public override bool validate(TestContext context) {
    if (context.zipArchive.isEncrypted) return false;
    return true;
  }
}