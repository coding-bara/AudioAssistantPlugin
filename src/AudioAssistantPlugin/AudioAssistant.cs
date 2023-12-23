namespace Loupedeck.AudioAssistantPlugin {
  using System;
  using System.Collections.Generic;

  public class AudioAssistant : Plugin {
    public override Boolean UsesApplicationApiOnly => true;
    public override Boolean HasNoApplication => true;

    public static AudioDevice OutputA;
    public static AudioDevice OutputB;

    public static AudioDevice InputA;
    public static AudioDevice InputB;

    public static AudioDeviceActive OutputActive;
    public static AudioDeviceActive InputActive;

    public readonly AudioDeviceStateMonitoring _stateMonitoring;

    public AudioAssistant() {
      Logger.Init(Log);
      Resources.Init(Assembly);

      var config = Config.CreateOrLoad();

      OutputActive = new AudioDeviceActive("Output");
      OutputA = new AudioDevice(new AudioDeviceAPI(config.ExecutablePath, config.OutputA.Name), config.OutputA.Name, config.OutputA.Type);
      OutputB = new AudioDevice(new AudioDeviceAPI(config.ExecutablePath, config.OutputB.Name), config.OutputB.Name, config.OutputB.Type);

      InputActive = new AudioDeviceActive("Input");
      InputA = new AudioDevice(new AudioDeviceAPI(config.ExecutablePath, config.InputA.Name), config.InputA.Name, config.InputA.Type);
      InputB = new AudioDevice(new AudioDeviceAPI(config.ExecutablePath, config.InputB.Name), config.InputB.Name, config.InputB.Type);

      _stateMonitoring = new AudioDeviceStateMonitoring(
        config,
        new List<AudioDevice> {
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
        OutputActive.Instance = OutputA;
      else
        OutputActive.Instance = OutputB;

      InputA.Init();
      InputB.Init();

      if (InputA.IsDefault())
        InputActive.Instance = InputA;
      else
        InputActive.Instance = InputB;

      _stateMonitoring.Start();
    }

    public override void Unload() {
      _stateMonitoring?.Stop();

      base.Unload();
    }
  }
}
