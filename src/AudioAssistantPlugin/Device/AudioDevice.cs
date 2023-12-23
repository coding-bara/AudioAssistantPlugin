namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public class AudioDevice {
    private readonly AudioDeviceAPI _api;
    private readonly AudioDeviceState _state;
    private readonly String _name;
    private readonly String _type;

    public AudioDevice(AudioDeviceAPI api, String name, String type) {
      _api = api;
      _name = name;
      _type = type;

      _state = new AudioDeviceState();
    }

    public void Init() {
      _state.IsMuted = _api.IsMuted();
      _state.Volume = _api.GetVolume();
    }

    public event AudioDeviceState.StateChangedEvent StateChanged {
      add => _state.StateChanged += value;
      remove => _state.StateChanged -= value;
    }

    public String Name => _name;
    public String Type => _type;
    public AudioDeviceAPI API => _api;
    public AudioDeviceState State => _state;

    public void ChangeVolume(Int32 volumeStep) {
      if (_state.IsMuted)
        return;

      var newVolume = Math.Max(0, Math.Min(100, _state.Volume + volumeStep));

      if (newVolume == _state.Volume)
        return;

      _api.ChangeVolume(volumeStep);
      _state.Volume = newVolume;
    }

    public void ToggleMute() {
      if (_state.IsMuted)
        Unmute();
      else
        Mute();
    }

    public void Unmute() {
      _api.Unmute();
      _state.IsMuted = _api.IsMuted();
    }

    public void Mute() {
      _api.Mute();
      _state.IsMuted = _api.IsMuted();
    }

    public Boolean IsDefault() => _api.IsDefault();

    public void SetAsDefault() {
      _api.SetAsDefault();
    }

    public String GetDialValue() => _state.IsMuted
      ? "-"
      : _state.Volume.ToString();
  }
}
