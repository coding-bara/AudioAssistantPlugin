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

    public BitmapImage GetDialIcon() => EmbeddedResources.ReadImage(
      Instance.State.IsMuted
        ? $"{nameof(Loupedeck)}.{nameof(AudioAssistantPlugin)}.Resources.Icons.Size50x50.{_type}.Muted.png"
        : $"{nameof(Loupedeck)}.{nameof(AudioAssistantPlugin)}.Resources.Icons.Size50x50.{_type}.Normal.png"
    );

    public BitmapImage GetButtonIcon(String state = default) {
      String resourceName;

      if (state != default)
        resourceName = $"{nameof(Loupedeck)}.{nameof(AudioAssistantPlugin)}.Resources.Icons.Size80x80.{_type}.{Instance.Type}.{state}.png";
      else
        resourceName = $"{nameof(Loupedeck)}.{nameof(AudioAssistantPlugin)}.Resources.Icons.Size80x80.{_type}.{Instance.Type}.png";

      return EmbeddedResources.ReadImage(resourceName);
    }
  }
}
