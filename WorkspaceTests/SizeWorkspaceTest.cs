using Beacon.WorkspaceTests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

[TestName("Size")]
[TestDescription("Check if any files in the workspace is to large")]
class SizeWorkspaceTest : WorkspaceTest {
  public long maxLeng = 64 * 1024 * 1024;
  public override bool validate(TestContext context) 
  {
    
    foreach (ZipArchiveEntry entery in context.zipArchive.entries)
    {
      if (entery.Length >= maxLeng) return false;
      
    }
    return true;
    
  }
}
