namespace Loupedeck.AudioAssistantPlugin {
  public class AdjustDeviceKnobOutput : AAdjustDeviceKnob {
    protected override ActiveDevice ActiveDevice => AudioAssistant.ActiveOutput;

    public AdjustDeviceKnobOutput() : base(
      "Adjust Output",
      "Output Device",
      "Adjust the active output device volume and mute or unmute the active output device."
    ) { }
  }
}
