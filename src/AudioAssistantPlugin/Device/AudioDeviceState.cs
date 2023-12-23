namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public class AudioDeviceState {
    private Int32 _volume;
    private Boolean _isMuted;

    private static readonly Object _volumeLock = new Object();
    private static readonly Object _isMutedLock = new Object();

    public delegate void StateChangedEvent();
    public event StateChangedEvent StateChanged;

    public Boolean IsMuted {
      get {
        lock (_isMutedLock)
          return _isMuted;
      }
      set {
        lock (_isMutedLock)
          if (value != _isMuted) {
            _isMuted = value;
            StateChanged?.Invoke();
          }
      }
    }

    public Int32 Volume {
      get {
        lock (_volumeLock)
          return _volume;
      }
      set {
        lock (_volumeLock)
          if (value != _volume) {
            _volume = value;
            StateChanged?.Invoke();
          }
      }
    }
  }
}
