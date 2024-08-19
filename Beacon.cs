﻿/*
* C# Program for checking student-subitted code and determining if it at meets some standard
* for what could be considered "safe" code.
*
* SHOULD INCLUDE
* 1. Classes and objects
* 2. Custom threads
* 3. Custom events and delegates
* 4. Interfaces (custom and built-in)
* 5. Polymorphism
* 6. Custom and built-in exceptions
* 7. Security measures
*/
using System.IO.Compression;
using Beacon.WorkspaceTests;

namespace Beacon {
  class Program {
    static void Main(string[] args) {
      // dotnet run ./test.zip
      Console.WriteLine($"passed args: {string.Join(", ", args)}");

      ZipArchive zip = ZipFile.OpenRead(args[0]);
      TestContext context = new TestContext(zip);

      // planned tests should probably check for the following:
      // 1. if the zip file is password protected
      // * - if the zip file is password protected, check if the password can be cracked
      // 2. if the zip file contains any malicious files
      // 3. if the zip file contains any files that are too large
      WorkspaceTestRunner runner = new WorkspaceTestRunner();
      runner.enableTest<ExtensionWorkspaceTest>();
      List<TestResult> results = runner.runTests(context);

      results.ForEach((result) => Console.WriteLine($"{result.name}: {(result.passed ? "Passed" : "Failed")}"));


      //steps

      //prompt user to upload file
      //check if file is a zip file
      //check zip size

      //check if zip file is password protected
      //if password protected, check if password can be cracked

      //prompt for expected file types
      //check if zip file contains any malicious files

      //prompt for appropriate size when unzipped
      //start unzip
      //stop unzip when prompted size is reached
    }
  }
}
