namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public abstract class AAdjustDeviceKnob : BaseKnob {
    protected AAdjustDeviceKnob(String actionGroup, String actionName, String actionDescription) : base(actionGroup, actionName, actionDescription) { }

    protected abstract ActiveDevice ActiveDevice { get; }

    public override Boolean OnKnobSetup() {
      ActiveDevice.PreSwitch += OnDevicePreSwitch;

      if (ActiveDevice.I != null)
        ActiveDevice.I.StateHasChanged += UpdateKnob;

      return true;
    }

    public override void OnKnobTeardown() {
      ActiveDevice.PreSwitch -= OnDevicePreSwitch;

      if (ActiveDevice.I != null)
        ActiveDevice.I.StateHasChanged -= UpdateKnob;
    }

    private void OnDevicePreSwitch(Device currentDevice, Device nextDevice) {
      if (currentDevice != null)
        currentDevice.StateHasChanged -= UpdateKnob;

      if (nextDevice != null)
        nextDevice.StateHasChanged += UpdateKnob;

      UpdateKnob();
    }

    public override Boolean OnKnobPress() {
      ActiveDevice.I.ToggleMute();

      return true;
    }

    public override Boolean OnKnobTurn(Int32 steps) {
      ActiveDevice.I.ChangeVolume(steps);

      return true;
    }

    public override BitmapImage GetKnobIcon(PluginImageSize _) => ActiveDevice.I.GetKnobIcon(GetIconBasePath(50), ActiveDevice.Category);

    public override String GetKnobValue() => ActiveDevice.I.GetKnobText();
  }
}
