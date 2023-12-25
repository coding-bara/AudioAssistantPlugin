namespace Loupedeck.AudioAssistantPlugin {
  using System;
  using System.Collections.Generic;
  using System.IO;

  public class AudioAssistant : Plugin {
    public override Boolean UsesApplicationApiOnly => true;
    public override Boolean HasNoApplication => true;

    public static String RootPath;

    public static Device OutputA;
    public static Device OutputB;

    public static Device InputA;
    public static Device InputB;

    public static ActiveDevice ActiveOutput;
    public static ActiveDevice ActiveInput;

    public readonly DeviceStateMonitoring _stateMonitoring;

    public AudioAssistant() {
      Logger.Init(Log);
      Resources.Init(Assembly);

      RootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), nameof(Loupedeck), "Plugins", nameof(AudioAssistant), "win");

      var config = Config.CreateOrLoad();

      ActiveOutput = new ActiveDevice("Output");
      OutputA = new Device(new DeviceAPI(config.ExePath, config.OutputA.Name), config.OutputA.Name, config.OutputA.Type);
      OutputB = new Device(new DeviceAPI(config.ExePath, config.OutputB.Name), config.OutputB.Name, config.OutputB.Type);

      ActiveInput = new ActiveDevice("Input");
      InputA = new Device(new DeviceAPI(config.ExePath, config.InputA.Name), config.InputA.Name, config.InputA.Type);
      InputB = new Device(new DeviceAPI(config.ExePath, config.InputB.Name), config.InputB.Name, config.InputB.Type);

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
        ActiveOutput.Instance = OutputA;
      else
        ActiveOutput.Instance = OutputB;

      InputA.Init();
      InputB.Init();

      if (InputA.IsDefault())
        ActiveInput.Instance = InputA;
      else
        ActiveInput.Instance = InputB;

      _stateMonitoring.Start();
    }

    public override void Unload() {
      _stateMonitoring?.Stop();

      base.Unload();
    }
  }
}
