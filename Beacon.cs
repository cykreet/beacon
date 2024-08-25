/*
  C# Program for checking student-submitted code and determining if it at least meets some standard
  for what could be considered "safe" code.
*/

using System;
using System.IO;
using System.Windows.Forms;
using Beacon.Plugins;
using Beacon.WorkspaceTests;

namespace Beacon;

internal static class Program {
  private static WorkspaceTestRunner? testRunner;

  [STAThread]
  private static void Main(string[] args) {
    testRunner = new WorkspaceTestRunner();
    testRunner.registerTest(new EncryptionWorkspaceTest());
    testRunner.registerTest(new ExtensionWorkspaceTest());
    testRunner.registerTest(new JavaScriptWorkspaceTest());
    testRunner.registerTest(new SizeWorkspaceTest());

    var pluginPath = Path.Combine(Application.StartupPath, "plugins");
    var plugins = PluginLoader.loadPlugins(pluginPath);
    foreach (var plugin in plugins) {
      if (plugin is not WorkspaceTest pluginTest) continue;
      testRunner.registerTest(pluginTest);
      Sentry.info($"Registered plugin {plugin.pluginName}");
    }

    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new MainForm());
  }

  public static WorkspaceTestRunner? getTestRunner() => testRunner;
}