using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WorkspaceTests;

[TestName("Size")]
[TestDescription("Check if any files in the workspace is to large")]
internal class SizeWorkspaceTest : WorkspaceTest {
  private const long maxLeng = 64 * 1024 * 1024;

  protected override bool validate(TestContext context) {
    return context.zipArchive.entries.All((entry) => entry.Length < maxLeng);
  }
}
