using System.Reflection;

namespace Beacon.WorkspaceTests;

class TestNotFoundException(string name) : Exception($"Test {name} not found.") { }

class TestResult {
  public string? name { get; set; } = "Unknown";
  public string? description { get; set; } = "No description provided.";
  public bool passed { get; set; }
}

class WorkspaceTestRunner {
  public event EventHandler<TestResult>? testComplete;
  private readonly WorkspaceTest[] tests = [
    new ExtensionWorkspaceTest(),
    // new SizeWorkspaceTest()
  ];

  public void enableTest<Type>() where Type : WorkspaceTest {
    foreach (WorkspaceTest test in tests) {
      if (test.GetType() != typeof(Type)) continue;
      test.enable();
      return;
    }

    throw new TestNotFoundException(typeof(Type).Name);
  }

  public void disableTest<Type>() where Type : WorkspaceTest {
    foreach (WorkspaceTest test in tests) {
      if (test.GetType() != typeof(Type)) continue;
      test.disable();
      return;
    }

    throw new TestNotFoundException(typeof(Type).Name);
  }

  public void runTests(TestContext context) {
    foreach (WorkspaceTest test in tests) {
      if (!test.enabled) continue;
      Thread thread = new Thread(() => {
        Console.WriteLine($"Running test {test.GetType().Name} in thread {Environment.CurrentManagedThreadId}");
        Type testType = test.GetType();
        string? testName = testType.GetCustomAttribute<TestNameAttribute>()?.name;
        string? testDescription = testType.GetCustomAttribute<TestDescriptionAttribute>()?.description;
        bool passed = test.validate(context);
        this.onTestComplete(new TestResult {
          name = testName,
          description = testDescription,
          passed = passed
        });
      });

      thread.Start();
    };
  }

  protected void onTestComplete(TestResult result) {
    testComplete?.Invoke(this, result);
  }
}