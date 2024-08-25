namespace Beacon.Plugins;

public interface BeaconPlugin {
  string pluginName { get; set; }
  void onPluginLoaded();
}