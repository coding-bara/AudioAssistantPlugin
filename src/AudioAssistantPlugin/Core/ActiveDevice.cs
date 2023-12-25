namespace Loupedeck.AudioAssistantPlugin {
  using System;
  using System.IO;

  public class ActiveDevice {
    public delegate void SwitchEvent(Device currentDevice, Device nextDevice);
    public event SwitchEvent PreSwitch;

    private readonly String _type;
    private Device _instance;

    public ActiveDevice(String type) {
      _type = type;
    }

    public Device Instance {
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

    public BitmapImage GetDialIcon() {
      var filePath = Instance.State.IsMuted
        ? Path.Combine(GetIconBasePath(50), $"{_type}.Muted.png")
        : Path.Combine(GetIconBasePath(50), $"{_type}.Normal.png");

      return BitmapImage.FromFile(filePath);
    }

    public BitmapImage GetButtonIcon(String state = default) {
      var filePath = state != default
        ? Path.Combine(GetIconBasePath(80), _type, $"{Instance.Type}.{state}.png")
        : Path.Combine(GetIconBasePath(80), _type, $"{Instance.Type}.png");

      return BitmapImage.FromFile(filePath);
    }

    private String GetIconBasePath(Int32 size) => Path.Combine(AudioAssistant.RootPath, "Resources", "Icons", $"Size{size}x{size}");
  }
}
