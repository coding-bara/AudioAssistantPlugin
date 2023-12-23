namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public abstract class AudioActionBaseControl : PluginDynamicAdjustment {
    protected AudioActionBaseControl(String displayName, String description, String groupName) : base(displayName, description, groupName, true) { }

    protected abstract AudioDeviceActive Current { get; }

    protected override Boolean OnLoad() {
      Current.PreSwitch += OnDevicePreSwitch;

      if (Current.Instance != null)
        Current.Instance.StateChanged += OnDeviceStateChanged;

      AdjustmentValueChanged();
      ActionImageChanged();

      return base.OnLoad();
    }

    protected override Boolean OnUnload() {
      Current.PreSwitch -= OnDevicePreSwitch;

      if (Current.Instance != null)
        Current.Instance.StateChanged -= OnDeviceStateChanged;

      return base.OnUnload();
    }

    private void OnDeviceStateChanged() {
      AdjustmentValueChanged();
      ActionImageChanged();
    }

    private void OnDevicePreSwitch(AudioDevice currentDevice, AudioDevice nextDevice) {
      if (currentDevice != null)
        currentDevice.StateChanged -= OnDeviceStateChanged;

      if (nextDevice != null)
        nextDevice.StateChanged += OnDeviceStateChanged;

      AdjustmentValueChanged();
      ActionImageChanged();
    }

    protected override void ApplyAdjustment(String actionParameter, Int32 volumeStep) {
      Current.Instance.ChangeVolume(volumeStep);
      AdjustmentValueChanged();
    }

    protected override void RunCommand(String actionParameter) {
      Current.Instance.ToggleMute();
      ActionImageChanged();
    }

    protected override String GetAdjustmentValue(String actionParameter) => Current.Instance.GetDialValue();

    protected override BitmapImage GetAdjustmentImage(String actionParameter, PluginImageSize imageSize) => Current.GetDialIcon();
  }
}
