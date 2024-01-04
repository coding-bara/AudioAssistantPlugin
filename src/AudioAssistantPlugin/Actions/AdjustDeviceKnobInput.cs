namespace Loupedeck.AudioAssistantPlugin {
  public class AdjustDeviceKnobInput : AAdjustDeviceKnob {
    protected override ActiveDevice ActiveDevice => AudioAssistant.ActiveInput;

    public AdjustDeviceKnobInput() : base(
      "Adjust Input",
      "Input Device",
      "Adjust the active input device volume and mute or unmute the active input device."
    ) { }
  }
}
