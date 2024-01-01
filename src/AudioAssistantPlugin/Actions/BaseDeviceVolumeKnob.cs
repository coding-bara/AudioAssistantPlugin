namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public abstract class BaseDeviceVolumeKnob : BaseKnobAction {
    protected BaseDeviceVolumeKnob(String actionGroup, String actionName, String actionDescription) : base(actionGroup, actionName, actionDescription) { }

    protected abstract ActiveDevice ActiveDevice { get; }

    public override void OnKnobSetup() {
      ActiveDevice.PreSwitch += OnDevicePreSwitch;

      if (ActiveDevice.I != null)
        ActiveDevice.I.StateHasChanged += UpdateKnob;
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

    public override BitmapImage GetKnobIcon() => ActiveDevice.I.GetKnobIcon(ActiveDevice.Category);

    public override String GetKnobText() => ActiveDevice.I.GetKnobText();
  }
}
