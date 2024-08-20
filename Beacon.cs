/*
  C# Program for checking student-subitted code and determining if it at meets some standard
  for what could be considered "safe" code.

  SHOULD INCLUDE
  1. (done) Classes and objects
  2. (done) Custom threads
  3. (done) Custom events and delegates
  4. Interfaces (custom and built-in)
  5. (done) Polymorphism
  6. (done) Custom and built-in exceptions
  7. Security measures
*/
using Beacon.WorkspaceTests;

namespace Beacon {
  class Program {
    static readonly ManualResetEvent quitEvent = new ManualResetEvent(false);

    static void Main(string[] args) {
      Console.CancelKeyPress += (sender, eventArgs) => {
        Sentry.warn("\n\nExiting...");
        eventArgs.Cancel = true;
        quitEvent.Set();
      };

      // dotnet run ./test.zip
      // todo: could optionally include a "sanitise" flag to remove unwanted files
      Sentry.debug($"passed args: {string.Join(", ", args)}");

      ZipReader zipReader = new ZipReader(args[0]);
      WorkspaceTestRunner testRunner = new WorkspaceTestRunner();
      testRunner.enableTest<ExtensionWorkspaceTest>();
      testRunner.enableTest<EncryptionWorkspaceTest>();
      testRunner.testComplete += onTestComplete;
      testRunner.runTests(zipReader);

      quitEvent.WaitOne();

      // steps
      // prompt user to upload file
      // check if file is a zip file
      // check zip size

      // check if zip file is password protected
      // if password protected, check if password can be cracked

      // prompt for expected file types
      // check if zip file contains any malicious files

      // prompt for appropriate size when unzipped
      // start unzip
      // stop unzip when prompted size is reached
    }

    static void onTestComplete(object? sender, TestResult result) {
      // colours: https://stackoverflow.com/a/74807043
      Sentry.info($"{result.name} Test completed: \x1b[1m{(result.passed ? "\x1b[92mPASSED" : "\x1b[91mFAILED")}\x1b[22m\x1b[39m");
    }
  }
}
