namespace Loupedeck.AudioAssistantPlugin {
  using System;
  using System.Collections.Generic;
  using System.IO;

  public class AudioAssistant : Plugin {
    public override Boolean UsesApplicationApiOnly => true;
    public override Boolean HasNoApplication => true;

    public static String ResourcesPath;

    public static Device OutputA;
    public static Device OutputB;

    public static Device InputA;
    public static Device InputB;

    public static ActiveDevice ActiveOutput;
    public static ActiveDevice ActiveInput;

    private readonly DeviceStateMonitoring _stateMonitoring;

    public AudioAssistant() {
      Logger.Init(Log);
      Resources.Init(Assembly);

      var resourcesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), nameof(Loupedeck), "Plugins", nameof(AudioAssistant), "win", "Resources");
      var pluginPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".loupedeck", nameof(AudioAssistant));

      if (!Directory.Exists(pluginPath))
        Directory.CreateDirectory(pluginPath);

      var config = new ConfigLoader(pluginPath).Load();
      var api = new ToolAPI(config.ExePath);

      ResourcesPath = resourcesPath;

      ActiveOutput = new ActiveDevice("Output");
      OutputA = new Device(api, config.OutputA.Name, config.OutputA.Type);
      OutputB = new Device(api, config.OutputB.Name, config.OutputB.Type);

      ActiveInput = new ActiveDevice("Input");
      InputA = new Device(api, config.InputA.Name, config.InputA.Type);
      InputB = new Device(api, config.InputB.Name, config.InputB.Type);

      _stateMonitoring = new DeviceStateMonitoring(
        config,
        new List<Device> {
          OutputA,
          OutputB,
          InputA,
          InputB
        }
      );
    }

    public override void Load() {
      base.Load();

      OutputA.Init();
      OutputB.Init();

      if (OutputA.IsDefault())
        ActiveOutput.I = OutputA;
      else
        ActiveOutput.I = OutputB;

      InputA.Init();
      InputB.Init();

      if (InputA.IsDefault())
        ActiveInput.I = InputA;
      else
        ActiveInput.I = InputB;

      _stateMonitoring.Start();
    }

    public override void Unload() {
      _stateMonitoring?.Stop();

      base.Unload();
    }
  }
}
