namespace Loupedeck.AudioAssistantPlugin {
  public class SwitchDeviceButtonOutput : ASwitchDeviceButton {
    protected override ActiveDevice ActiveDevice => AudioAssistant.ActiveOutput;
    protected override Device DeviceOptionA => AudioAssistant.OutputA;
    protected override Device DeviceOptionB => AudioAssistant.OutputB;

    public SwitchDeviceButtonOutput() : base(
      "Switch Output",
      "Output Device",
      "Switch between output device option a and b."
    ) { }
  }
}
