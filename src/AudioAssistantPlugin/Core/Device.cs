namespace Loupedeck.AudioAssistantPlugin {
  using System;
  using System.IO;

  public class Device {
    private readonly ToolAPI _api;
    private readonly String _name;
    private readonly String _type;

    private readonly DeviceState _state;

    public Device(ToolAPI api, String name, String type) {
      _api = api;
      _name = name;
      _type = type;

      _state = new DeviceState();
    }

    public void Init() => Sync();

    public event DeviceState.HasChangedEvent StateHasChanged {
      add => _state.HasChanged += value;
      remove => _state.HasChanged -= value;
    }

    public String Name => _name;

    public void ChangeVolume(Int32 volumeStep) {
      if (_state.IsMuted)
        return;

      var newVolume = Math.Max(0, Math.Min(100, _state.Volume + volumeStep));

      if (newVolume == _state.Volume)
        return;

      _api.ChangeVolume(_name, volumeStep);
      _state.Volume = newVolume;
    }

    public void ToggleMute() {
      if (_state.IsMuted)
        Unmute();
      else
        Mute();
    }

    public void Unmute() {
      _api.Unmute(_name);
      _state.IsMuted = _api.IsMuted(_name);
    }

    public void Mute() {
      _api.Mute(_name);
      _state.IsMuted = _api.IsMuted(_name);
    }

    public Boolean IsDefault() => _api.IsDefault(_name);

    public void SetAsDefault() => _api.SetAsDefault(_name);

    public void Sync() {
      _state.IsMuted = _api.IsMuted(_name);
      _state.Volume = _api.GetVolume(_name);
    }

    public String GetKnobText() => _state.IsMuted
      ? "-"
      : _state.Volume.ToString();

    public BitmapImage GetKnobIcon(String category) {
      var filePath = _state.IsMuted
        ? Path.Combine(GetIconBasePath(50), $"{category}.Muted.png")
        : Path.Combine(GetIconBasePath(50), $"{category}.Normal.png");

      return BitmapImage.FromFile(filePath);
    }

    public BitmapImage GetButtonIcon(String category, String state) {
      var filePath = state != default
        ? Path.Combine(GetIconBasePath(80), category, $"{_type}.{state}.png")
        : Path.Combine(GetIconBasePath(80), category, $"{_type}.png");

      return BitmapImage.FromFile(filePath);
    }

    private String GetIconBasePath(Int32 size) => Path.Combine(AudioAssistant.RootPath, "Resources", "Icons", $"Size{size}x{size}");
  }
}
