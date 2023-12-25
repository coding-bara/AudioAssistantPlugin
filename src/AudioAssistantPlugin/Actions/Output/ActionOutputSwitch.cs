namespace Loupedeck.AudioAssistantPlugin {
  public class ActionOutputSwitch : ActionBaseSwitch {
    protected override ActiveDevice ActiveDevice => AudioAssistant.ActiveOutput;
    protected override Device DeviceOptionA => AudioAssistant.OutputA;
    protected override Device DeviceOptionB => AudioAssistant.OutputB;

    public ActionOutputSwitch() : base("Audio Output Switch", "You can switch between output device option a and b.", "Output") { }
  }
}
