namespace Loupedeck.AudioAssistantPlugin {
  using System;
  using System.IO;

  [Serializable]
  public class Config {
    public AudioDeviceConfig OutputA { get; set; }
    public AudioDeviceConfig OutputB { get; set; }

    public AudioDeviceConfig InputA { get; set; }
    public AudioDeviceConfig InputB { get; set; }

    public String ExecutablePath { get; set; }
    public Int32 MonitoringRateInMS { get; set; }

    public static Config CreateOrLoad() {
      var userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
      var pluginPath = Path.Combine(userProfilePath, Path.Combine(".loupedeck", "audio-assistant"));

      if (!Directory.Exists(pluginPath))
        Directory.CreateDirectory(pluginPath);

      var configFilePath = Path.Combine(pluginPath, "config.json");

      if (File.Exists(configFilePath)) {
        var existingConfig = JsonHelpers.DeserializeAnyObjectFromFile<Config>(configFilePath);

        #if LOGGING
        Logger.Verbose($"Existing config loaded: {JsonHelpers.SerializeAnyObject(existingConfig)}");
        #endif

        return existingConfig;
      }

      var defaultConfig = new Config {
        ExecutablePath = @".\Resources\Executables\svcl.exe",
        InputA = new AudioDeviceConfig {
          Name = "Microphone",
          Type = "Microphone"
        },
        InputB = new AudioDeviceConfig {
          Name = "-",
          Type = "-"
        },
        OutputA = new AudioDeviceConfig {
          Name = "Headset",
          Type = "Headset"
        },
        OutputB = new AudioDeviceConfig {
          Name = "Speaker",
          Type = "Speaker"
        },
        MonitoringRateInMS = 1000
      };
      JsonHelpers.SerializeAnyObjectToFile(defaultConfig, configFilePath);

      #if LOGGING
      Logger.Verbose($"Default config loaded: {JsonHelpers.SerializeAnyObject(defaultConfig)}");
      #endif

      return defaultConfig;
    }
  }
}
