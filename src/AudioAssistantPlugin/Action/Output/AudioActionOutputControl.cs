namespace Loupedeck.AudioAssistantPlugin {
  public class AudioActionOutputControl : AudioActionBaseControl {
    protected override AudioDeviceActive Current => AudioAssistant.OutputActive;

    public AudioActionOutputControl() : base("Audio Output Control", "You can adjust the output device volume and mute or unmute the output device.", "Output") { }
  }
}
