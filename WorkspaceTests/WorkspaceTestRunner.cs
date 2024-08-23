using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Beacon.WorkspaceTests;

internal class TestNotFoundException(string name) : Exception($"Test {name} not found.") {
}

internal readonly struct TestResult(string name, string description, bool passed, IReadOnlyList<string> warnings) {
  public readonly string name = name;
  public readonly string description = description;
  public readonly bool passed = passed;
  public readonly IReadOnlyList<string> warnings = warnings;
}

internal class WorkspaceTestRunner {
  private readonly WorkspaceTest[] tests = [
    new SizeWorkspaceTest(),
    new ExtensionWorkspaceTest(),
    new EncryptionWorkspaceTest()
    // new CsharpWorkspaceTest(),
    // new JavaScriptWorkspaceTest(),
  ];

  public event EventHandler<TestResult>? testComplete;

  public void enableTest(Type testType) {
    if (!typeof(WorkspaceTest).IsAssignableFrom(testType))
      throw new ArgumentException($"Type '{testType.Name}' is not a subclass of WorkspaceTest");

    foreach (var test in this.tests) {
      if (test.GetType() != testType) continue;
      test.enable();
      return;
    }

    throw new TestNotFoundException(testType.Name);
  }

  public void disableTest(Type testType) {
    if (!typeof(WorkspaceTest).IsAssignableFrom(testType))
      throw new ArgumentException($"Type '{testType.Name}' is not a subclass of WorkspaceTest");

    foreach (var test in this.tests) {
      if (test.GetType() != testType) continue;
      test.disable();
      return;
    }

    throw new TestNotFoundException(testType.Name);
  }

  public void runTests(ZipReader zipArchive) {
    var context = new TestContext {
      zipArchive = zipArchive,
      workspaceType = WorkspaceType.Javascript
    };

    foreach (var test in this.tests) {
      if (!test.enabled) continue;
      var testType = test.GetType();
      var testName = testType.GetCustomAttribute<TestNameAttribute>()?.name ?? "Unknown";
      var testDescription = testType.GetCustomAttribute<TestDescriptionAttribute>()?.description ??
                            "No description provided.";

      ThreadPool.QueueUserWorkItem(_ => {
        Sentry.debug($"Running test {test.GetType().Name} in thread {Environment.CurrentManagedThreadId}");
        try {
          var result = test.validateAndWarn(context);
          this.onTestComplete(new TestResult(testName, testDescription, result.passed, result.warnings));
        } catch (Exception exception) {
          this.onTestComplete(new TestResult(testName, testDescription, false,
            ["An unexpected error occurred while running the test."]));
          Sentry.error($"{testName} test failed with an error: {exception.Message}\n{exception.StackTrace}");
        }
      });
    }
  }

  private void onTestComplete(TestResult result) => testComplete?.Invoke(this, result);
}