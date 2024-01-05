namespace Loupedeck.AudioAssistantPlugin {
  using System;
  using System.IO;

  public class ConfigLoader {
    private readonly String _pluginPath;
    private readonly String _resourcesPath;

    public ConfigLoader(String pluginPath, String resourcesPath) {
      _pluginPath = pluginPath;
      _resourcesPath = resourcesPath;
    }

    public Config Load() {
      var configFilePath = Path.Combine(_pluginPath, "config.json");

      return File.Exists(configFilePath)
        ? UseExistingConfig(configFilePath)
        : UseDefaultConfig(configFilePath);
    }

    private Config UseDefaultConfig(String configFilePath) {
      var defaultConfig = new Config {
        InputA = new DeviceConfig {
          Name = "Microphone",
          Type = "Microphone"
        },
        OutputA = new DeviceConfig {
          Name = "Headset",
          Type = "Headset"
        }
      };
      JsonHelpers.SerializeAnyObjectToFile(defaultConfig, configFilePath);

      #if LOGGING
      Logger.Verbose($"Default config loaded: {JsonHelpers.SerializeAnyObject(defaultConfig)}");
      #endif

      return defaultConfig;
    }

    private Config UseExistingConfig(String configFilePath) {
      var existingConfig = JsonHelpers.DeserializeAnyObjectFromFile<Config>(configFilePath);

      EnrichExistingConfigWithDefaults(existingConfig);

      #if LOGGING
      Logger.Verbose($"Existing config loaded: {JsonHelpers.SerializeAnyObject(existingConfig)}");
      #endif

      return existingConfig;
    }

    private void EnrichExistingConfigWithDefaults(Config existingConfig) {
      if (string.IsNullOrWhiteSpace(existingConfig.ExePath))
        existingConfig.ExePath = Path.Combine(_resourcesPath, "SoundVolumeCommandLine", "svcl.exe");

      if (existingConfig.MonitoringRateInMS == default || existingConfig.MonitoringRateInMS <= 0)
        existingConfig.MonitoringRateInMS = 2500;

      if (existingConfig.OutputB == default)
        existingConfig.OutputB = new DeviceConfig {
          Name = "-",
          Type = "-"
        };

      if (string.IsNullOrWhiteSpace(existingConfig.OutputB.Name))
        existingConfig.OutputB.Name = "-";

      if (string.IsNullOrWhiteSpace(existingConfig.OutputB.Type))
        existingConfig.OutputB.Type = "-";

      if (existingConfig.InputB == default)
        existingConfig.InputB = new DeviceConfig {
          Name = "-",
          Type = "-"
        };

      if (string.IsNullOrWhiteSpace(existingConfig.InputB.Name))
        existingConfig.InputB.Name = "-";

      if (string.IsNullOrWhiteSpace(existingConfig.InputB.Type))
        existingConfig.InputB.Type = "-";
    }
  }
}
