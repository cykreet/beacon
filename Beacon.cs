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

using System;
using System.Windows.Forms;
using Beacon.WorkspaceTests;

namespace Beacon;

internal class Program {
  private static WorkspaceTestRunner? testRunner;

  [STAThread]
  private static void Main(string[] args) {
    testRunner = new WorkspaceTestRunner();
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new MainForm());

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

  public static WorkspaceTestRunner? getTestRunner() => testRunner;
}