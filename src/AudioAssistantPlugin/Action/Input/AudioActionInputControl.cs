namespace Loupedeck.AudioAssistantPlugin {
  public class AudioActionInputControl : AudioActionBaseControl {
    protected override AudioDeviceActive Current => AudioAssistant.InputActive;

    public AudioActionInputControl() : base("Audio Input Control", "You can adjust the input device volume and mute or unmute the input device.", "Input") { }
  }
}
