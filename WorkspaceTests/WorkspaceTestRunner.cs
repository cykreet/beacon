using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace WorkspaceTests;

internal class TestNotFoundException(string name) : Exception($"Test {name} not found.") { }

internal readonly struct TestResult(string name, string description, bool passed, IReadOnlyList<string> warnings) {
  public readonly string name = name;
  public readonly string description = description;
  public readonly bool passed = passed;
  public readonly IReadOnlyList<string> warnings = warnings;
}

internal class WorkspaceTestRunner {
  public event EventHandler<TestResult>? testComplete;
  private readonly WorkspaceTest[] tests = [
    new SizeWorkspaceTest(),
    new ExtensionWorkspaceTest(),
    new EncryptionWorkspaceTest(),
    // new CsharpWorkspaceTest(),
    // new JavaScriptWorkspaceTest(),
  ];

  public void enableTest<Type>() where Type : WorkspaceTest {
    foreach (var test in tests) {
      if (test.GetType() != typeof(Type)) continue;
      test.enable();
      return;
    }

    throw new TestNotFoundException(typeof(Type).Name);
  }

  public void disableTest<Type>() where Type : WorkspaceTest {
    foreach (var test in tests) {
      if (test.GetType() != typeof(Type)) continue;
      test.disable();
      return;
    }

    throw new TestNotFoundException(typeof(Type).Name);
  }

  public void runTests(ZipReader zipArchive) {
    var context = new TestContext {
      zipArchive = zipArchive
    };

    foreach (WorkspaceTest test in tests) {
      if (!test.enabled) continue;

      ThreadPool.QueueUserWorkItem((_) => {
        Sentry.debug($"Running test {test.GetType().Name} in thread {Environment.CurrentManagedThreadId}");
        var testType = test.GetType();
        var testName = testType.GetCustomAttribute<TestNameAttribute>()?.name;
        var testDescription = testType.GetCustomAttribute<TestDescriptionAttribute>()?.description;
        var result = test.validateAndWarn(context);
        this.onTestComplete(new TestResult(testName ?? "Unknown", testDescription ?? "No description provided.", result.passed, result.warnings));
      });
    };
  }

  private void onTestComplete(TestResult result) {
    testComplete?.Invoke(this, result);
  }
}