namespace Loupedeck.AudioAssistantPlugin {
  public class AudioActionOutputControl : AudioActionBaseControl {
    protected override AudioDeviceActive Current => AudioAssistant.OutputActive;

    public AudioActionOutputControl() : base("Audio Output Control", "Adjust, mute or unmute the output volume of the active output device.", "Output") { }
  }
}
