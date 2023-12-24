namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public class AudioDeviceActive {
    public delegate void SwitchEvent(AudioDevice currentDevice, AudioDevice nextDevice);
    public event SwitchEvent PreSwitch;

    private readonly String _type;
    private AudioDevice _instance;

    public AudioDeviceActive(String type) {
      _type = type;
    }

    public AudioDevice Instance {
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
      var resourceName = Instance.State.IsMuted
        ? $"{GetIconBasePath(50)}.{_type}.Muted.png"
        : $"{GetIconBasePath(50)}.{_type}.Normal.png";

      return EmbeddedResources.ReadImage(resourceName);
    }

    public BitmapImage GetButtonIcon(String state = default) {
      var resourceName = state != default
        ? $"{GetIconBasePath(80)}.{_type}.{Instance.Type}.{state}.png"
        : $"{GetIconBasePath(80)}.{_type}.{Instance.Type}.png";

      return EmbeddedResources.ReadImage(resourceName);
    }

    private String GetIconBasePath(Int32 size) => $"{nameof(Loupedeck)}.{nameof(AudioAssistantPlugin)}.Resources.Icons.Size{size}x{size}";
  }
}
