namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public abstract class ActionBaseControl : PluginDynamicAdjustment {
    protected ActionBaseControl(String displayName, String description, String groupName) : base(displayName, description, groupName, true) { }

    protected abstract ActiveDevice ActiveDevice { get; }

    protected override Boolean OnLoad() {
      ActiveDevice.PreSwitch += OnDevicePreSwitch;

      if (ActiveDevice.Instance != null)
        ActiveDevice.Instance.StateChanged += OnDeviceStateChanged;

      AdjustmentValueChanged();
      ActionImageChanged();

      return base.OnLoad();
    }

    protected override Boolean OnUnload() {
      ActiveDevice.PreSwitch -= OnDevicePreSwitch;

      if (ActiveDevice.Instance != null)
        ActiveDevice.Instance.StateChanged -= OnDeviceStateChanged;

      return base.OnUnload();
    }

    private void OnDeviceStateChanged() {
      AdjustmentValueChanged();
      ActionImageChanged();
    }

    private void OnDevicePreSwitch(Device currentDevice, Device nextDevice) {
      if (currentDevice != null)
        currentDevice.StateChanged -= OnDeviceStateChanged;

      if (nextDevice != null)
        nextDevice.StateChanged += OnDeviceStateChanged;

      AdjustmentValueChanged();
      ActionImageChanged();
    }

    protected override void ApplyAdjustment(String actionParameter, Int32 volumeStep) {
      ActiveDevice.Instance.ChangeVolume(volumeStep);
      AdjustmentValueChanged();
    }

    protected override void RunCommand(String actionParameter) {
      ActiveDevice.Instance.ToggleMute();
      ActionImageChanged();
    }

    protected override String GetAdjustmentValue(String actionParameter) => ActiveDevice.Instance.GetDialValue();

    protected override BitmapImage GetAdjustmentImage(String actionParameter, PluginImageSize imageSize) => ActiveDevice.GetDialIcon();
  }
}
