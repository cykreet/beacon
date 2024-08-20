using System;

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
  public bool enabled { get; set; } = false;

  public void enable() => enabled = true;
  public void disable() => enabled = false;
  public abstract bool validate(TestContext context);
}
