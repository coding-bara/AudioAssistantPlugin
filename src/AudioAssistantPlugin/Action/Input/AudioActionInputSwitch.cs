namespace Loupedeck.AudioAssistantPlugin {
  public class AudioActionInputSwitch : AudioActionBaseSwitch {
    protected override AudioDeviceActive Current => AudioAssistant.InputActive;
    protected override AudioDevice OptionA => AudioAssistant.InputA;
    protected override AudioDevice OptionB => AudioAssistant.InputB;

    public AudioActionInputSwitch() : base("Audio Input Switch", "You can switch between input device option a and b.", "Input") { }
  }
}
