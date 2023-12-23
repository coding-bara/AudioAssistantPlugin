namespace Loupedeck.AudioAssistantPlugin {
  public class AudioActionInputControl : AudioActionBaseControl {
    protected override AudioDeviceActive Current => AudioAssistant.InputActive;

    public AudioActionInputControl() : base("Audio Input Control", "Adjust, mute or unmute the input volume of the active input device.", "Input") { }
  }
}
