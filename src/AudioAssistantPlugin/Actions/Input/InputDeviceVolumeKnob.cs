namespace Loupedeck.AudioAssistantPlugin {
  public class InputDeviceVolumeKnob : BaseDeviceVolumeKnob {
    protected override ActiveDevice ActiveDevice => AudioAssistant.ActiveInput;

    public InputDeviceVolumeKnob() : base(
      "Input Control",
      "Control Active Input Device",
      "Adjust the input device volume and mute or unmute the input device."
    ) { }
  }
}
