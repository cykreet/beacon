using System;
using System.Collections.Generic;

namespace WorkspaceTests;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
internal class TestNameAttribute(string name) : Attribute {
  public string name { get; } = name;
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
internal class TestDescriptionAttribute(string description) : Attribute {
  public string description { get; } = description;
}

internal struct TestContext {
  public ZipReader zipArchive { get; set; }
}

internal abstract class WorkspaceTest {
  private readonly List<string> warnings = [];
  public bool enabled { get; private set; }

  public void enable() => this.enabled = true;
  public void disable() => this.enabled = false;

  public (bool passed, IReadOnlyList<string> warnings) validateAndWarn(TestContext context) {
    var passed = this.validate(context);
    return (passed, this.warnings);
  }

  protected abstract bool validate(TestContext context);
  protected void addWarning(string warning) => this.warnings.Add(warning);
}