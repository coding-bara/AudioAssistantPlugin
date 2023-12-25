namespace Loupedeck.AudioAssistantPlugin {
  public class ActionInputControl : ActionBaseControl {
    protected override ActiveDevice ActiveDevice => AudioAssistant.ActiveInput;

    public ActionInputControl() : base("Audio Input Control", "You can adjust the input device volume and mute or unmute the input device.", "Input") { }
  }
}
