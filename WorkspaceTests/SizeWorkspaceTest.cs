using Beacon.WorkspaceTests;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Beacon.WorkspaceTests;

[TestName("Size")]
[TestDescription("Check if any files in the workspace is to large")]
internal class SizeWorkspaceTest : WorkspaceTest {
  private const long maxLeng = 64 * 1024 * 1024;

  protected override bool validate(TestContext context) {
    // todo: check individual file sizes and warn about largest file sizes
    // ExtensionWorkspace test does something similar.
    bool allFilesValid = true;
    foreach (ZipArchiveEntry entry in context.zipArchive.entries) 
    {
       
      
        if(context.zipArchive.entries.Length > maxLeng) 
        {
          this.addWarning("The file is to large");
          allFilesValid = false;
        }
        //context.zipArchive.entries.All(entry => entry.Length < maxLeng);
      
    }
    return allFilesValid;
    
  }
}