namespace Loupedeck.AudioAssistantPlugin {
  using System;

  [Serializable]
  public class DeviceConfig {
    public String Name { get; set; }
    public String Type { get; set; }
  }

  [Serializable]
  public class Config {
    public DeviceConfig OutputA { get; set; }
    public DeviceConfig OutputB { get; set; }

    public DeviceConfig InputA { get; set; }
    public DeviceConfig InputB { get; set; }

    public String ExePath { get; set; }
    public Int32 MonitoringRateInMS { get; set; } = 2500;
  }
}
