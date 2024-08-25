namespace Beacon.Plugins;

public interface Plugin {
  string pluginName { get; set; }
  bool validate();
}