namespace Loupedeck.AudioAssistantPlugin {
  using System;
  using System.IO;

  [Serializable]
  public class Config {
    public AudioDeviceConfig OutputA { get; set; }
    public AudioDeviceConfig OutputB { get; set; }

    public AudioDeviceConfig InputA { get; set; }
    public AudioDeviceConfig InputB { get; set; }

    public String ExePath { get; set; }
    public Int32 MonitoringRateInMS { get; set; }

    public static Config CreateOrLoad() {
      var userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
      var pluginPath = Path.Combine(userProfilePath, Path.Combine(".loupedeck", "audio-assistant"));

      if (!Directory.Exists(pluginPath))
        Directory.CreateDirectory(pluginPath);

      var configFilePath = Path.Combine(pluginPath, "config.json");

      return File.Exists(configFilePath)
        ? UseExistingConfig(configFilePath)
        : UseDefaultConfig(configFilePath);
    }

    private static Config UseDefaultConfig(String configFilePath) {
      var defaultConfig = new Config {
        InputA = new AudioDeviceConfig {
          Name = "Microphone",
          Type = "Microphone"
        },
        OutputA = new AudioDeviceConfig {
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
        existingConfig.ExePath = Path.Combine(AudioAssistant.RootPath, "Resources", "SoundVolumeCommandLine", "svcl.exe");

      if (existingConfig.MonitoringRateInMS == default)
        existingConfig.MonitoringRateInMS = 2500;

      if (existingConfig.OutputB == default)
        existingConfig.OutputB = new AudioDeviceConfig {
          Name = "-",
          Type = "-"
        };

      if (string.IsNullOrWhiteSpace(existingConfig.OutputB.Name))
        existingConfig.OutputB.Name = "-";

      if (string.IsNullOrWhiteSpace(existingConfig.OutputB.Type))
        existingConfig.OutputB.Type = "-";

      if (existingConfig.InputB == default)
        existingConfig.InputB = new AudioDeviceConfig {
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
