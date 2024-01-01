namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public class ActiveDevice {
    public delegate void SwitchEvent(Device currentDevice, Device nextDevice);
    public event SwitchEvent PreSwitch;

    private readonly String _category;
    private Device _instance;

    public ActiveDevice(String category) {
      _category = category;
    }

    public Device I {
      get => _instance;
      set {
        var currentDevice = _instance;
        var nextDevice = value;

        if (currentDevice != nextDevice) {
          PreSwitch?.Invoke(currentDevice, nextDevice);
          _instance = nextDevice;
        }
      }
    }
    public String Category => _category;
  }
}
