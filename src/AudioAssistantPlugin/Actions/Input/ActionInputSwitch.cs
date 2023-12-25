namespace Loupedeck.AudioAssistantPlugin {
  public class ActionInputSwitch : ActionBaseSwitch {
    protected override ActiveDevice ActiveDevice => AudioAssistant.ActiveInput;
    protected override Device DeviceOptionA => AudioAssistant.InputA;
    protected override Device DeviceOptionB => AudioAssistant.InputB;

    public ActionInputSwitch() : base("Audio Input Switch", "You can switch between input device option a and b.", "Input") { }
  }
}
