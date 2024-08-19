using System.IO.Compression;

namespace Beacon.WorkspaceTests;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
class TestNameAttribute(string name) : Attribute {
  public string name { get; } = name;
}

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
class TestDescriptionAttribute(string description) : Attribute {
  public string description { get; } = description;
}

class TestContext {
  public required ZipReader zipArchive { get; set; }
}

abstract class WorkspaceTest {
  public bool enabled { get; set; } = false;

  public void enable() => enabled = true;
  public void disable() => enabled = false;
  public abstract bool validate(TestContext context);
}
