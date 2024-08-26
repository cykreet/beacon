using Beacon.WorkspaceTests;

namespace Beacon.Plugins;

public interface BeaconPlugin {
  string pluginName { get; set; }
  WorkspaceTest[] workspaceTests { get; set; }
  void onPluginLoaded();
}