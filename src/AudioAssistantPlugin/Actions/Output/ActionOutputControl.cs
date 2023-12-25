namespace Loupedeck.AudioAssistantPlugin {
  public class ActionOutputControl : ActionBaseControl {
    protected override ActiveDevice ActiveDevice => AudioAssistant.ActiveOutput;

    public ActionOutputControl() : base("Audio Output Control", "You can adjust the output device volume and mute or unmute the output device.", "Output") { }
  }
}
