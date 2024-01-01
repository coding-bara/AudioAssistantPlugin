namespace Loupedeck.AudioAssistantPlugin {
  public class OutputDeviceVolumeKnob : BaseDeviceVolumeKnob {
    protected override ActiveDevice ActiveDevice => AudioAssistant.ActiveOutput;

    public OutputDeviceVolumeKnob() : base(
      "Output Control",
      "Control Active Output Device",
      "Adjust the output device volume and mute or unmute the output device."
    ) { }
  }
}
