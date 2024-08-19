using System.Reflection;

namespace Beacon.WorkspaceTests;

public class TestResult {
  public string? name { get; set; } = "Unknown";
  public string? description { get; set; } = "No description provided.";
  public bool passed { get; set; }
}

class WorkspaceTestRunner {
  private readonly WorkspaceTest[] tests = [
    new ExtensionBeaconTest(),
    // new SizeBeaconTest()
  ];

  public void enableTest<Type>() where Type : WorkspaceTest {
    foreach (WorkspaceTest test in tests) {
      if (test.GetType() == typeof(Type)) {
        test.enable();
        break;
      }
    }
  }

  public void disableTest<Type>() where Type : WorkspaceTest {
    foreach (WorkspaceTest test in tests) {
      if (test.GetType() == typeof(Type)) {
        test.disable();
        break;
      }
    }
  }

  public List<TestResult> runTests(TestContext context) {
    List<TestResult> results = [];
    foreach (WorkspaceTest test in tests) {
      if (!test.enabled) continue;

      Type testType = test.GetType();
      string? testName = testType.GetCustomAttribute<TestNameAttribute>()?.name;
      string? testDescription = testType.GetCustomAttribute<TestDescriptionAttribute>()?.description;
      bool passed = test.validate(context);
      results.Add(new TestResult { name = testName, description = testDescription, passed = passed });
    };

    return results;
  }
}