namespace Loupedeck.AudioAssistantPlugin {
  public class SwitchDeviceButtonInput : ASwitchDeviceButton {
    protected override ActiveDevice ActiveDevice => AudioAssistant.ActiveInput;
    protected override Device DeviceOptionA => AudioAssistant.InputA;
    protected override Device DeviceOptionB => AudioAssistant.InputB;

    public SwitchDeviceButtonInput() : base(
      "Switch Input",
      "Input Device",
      "Switch between input device option a and b."
    ) { }
  }
}
