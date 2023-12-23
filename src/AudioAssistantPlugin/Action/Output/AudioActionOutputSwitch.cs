namespace Loupedeck.AudioAssistantPlugin {
  public class AudioActionOutputSwitch : AudioActionBaseSwitch {
    protected override AudioDeviceActive Current => AudioAssistant.OutputActive;
    protected override AudioDevice OptionA => AudioAssistant.OutputA;
    protected override AudioDevice OptionB => AudioAssistant.OutputB;

    public AudioActionOutputSwitch() : base("Audio Output Switch", "Switch between output devices.", "Output") { }
  }
}
