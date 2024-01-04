namespace Loupedeck.AudioAssistantPlugin {
  using System;
  using System.IO;

  public class ConfigLoader {
    public static Config Load() {
      var configFilePath = Path.Combine(AudioAssistant.PluginPath, "config.json");

      return File.Exists(configFilePath)
        ? UseExistingConfig(configFilePath)
        : UseDefaultConfig(configFilePath);
    }

    private static Config UseDefaultConfig(String configFilePath) {
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

    private static Config UseExistingConfig(String configFilePath) {
      var existingConfig = JsonHelpers.DeserializeAnyObjectFromFile<Config>(configFilePath);

      EnrichExistingConfigWithDefaults(existingConfig);

      #if LOGGING
      Logger.Verbose($"Existing config loaded: {JsonHelpers.SerializeAnyObject(existingConfig)}");
      #endif

      return existingConfig;
    }

    private static void EnrichExistingConfigWithDefaults(Config existingConfig) {
      if (string.IsNullOrWhiteSpace(existingConfig.ExePath))
        existingConfig.ExePath = Path.Combine(AudioAssistant.ResourcesPath, "SoundVolumeCommandLine", "svcl.exe");

      if (existingConfig.MonitoringRateInMS == default)
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
