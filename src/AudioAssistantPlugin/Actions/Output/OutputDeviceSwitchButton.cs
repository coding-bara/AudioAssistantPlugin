namespace Loupedeck.AudioAssistantPlugin {
  public class OutputDeviceSwitchButton : BaseDeviceSwitchButton {
    protected override ActiveDevice ActiveDevice => AudioAssistant.ActiveOutput;
    protected override Device DeviceOptionA => AudioAssistant.OutputA;
    protected override Device DeviceOptionB => AudioAssistant.OutputB;

    public OutputDeviceSwitchButton() : base(
      "Output Control",
      "Switch Active Output Device",
      "Switch between output device option a and b."
    ) { }
  }
}
