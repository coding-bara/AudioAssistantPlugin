namespace Loupedeck.AudioAssistantPlugin {
  public class InputDeviceSwitchButton : BaseDeviceSwitchButton {
    protected override ActiveDevice ActiveDevice => AudioAssistant.ActiveInput;
    protected override Device DeviceOptionA => AudioAssistant.InputA;
    protected override Device DeviceOptionB => AudioAssistant.InputB;

    public InputDeviceSwitchButton() : base(
      "Input Control",
      "Switch Active Input Device",
      "Switch between input device option a and b."
    ) { }
  }
}
