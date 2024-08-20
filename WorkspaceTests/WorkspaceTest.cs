using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WorkspaceTests;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal class TestNameAttribute(string name) : Attribute {
  public string name { get; } = name;
}

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
internal class TestDescriptionAttribute(string description) : Attribute {
  public string description { get; } = description;
}

internal struct TestContext {
  public ZipReader zipArchive { get; set; }
}

internal abstract class WorkspaceTest {
  public bool enabled { get; private set; } = false;
  private readonly List<string> warnings = [];

  public void enable() => enabled = true;
  public void disable() => enabled = false;

  public (bool passed, IReadOnlyList<string> warnings) validateAndWarn(TestContext context) {
    var passed = validate(context);
    return (passed, this.warnings);
  }

  protected abstract bool validate(TestContext context);
  protected void addWarning(string warning) => this.warnings.Add(warning);
}
