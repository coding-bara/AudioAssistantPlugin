namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public class AudioDeviceAPI : GenericAPI {
    protected readonly String _name;

    public AudioDeviceAPI(String executablePath, String name) : base(executablePath) {
      _name = name;
    }

    public Int32 GetVolume() => RunCommand($"/GetColumnValue \"{_name}\" \"Volume Percent\"", RawOutputParser.GetVolume);

    public void SetVolume(Int32 volume) => RunCommand($"/SetVolume \"{_name}\" {volume}");

    public void ChangeVolume(Int32 volumeStep) => RunCommand($"/ChangeVolume \"{_name}\" {volumeStep}");

    public void Unmute() => RunCommand($"/Unmute \"{_name}\"");

    public void Mute() => RunCommand($"/Mute \"{_name}\"");

    public Boolean IsMuted() => RunCommand($"/GetColumnValue \"{_name}\" \"Muted\"", RawOutputParser.IsMuted);

    public void SetAsDefault() => RunCommand($"/SetDefault \"{_name}\" \"all\"");

    public Boolean IsDefault() => RunCommand($"/GetColumnValue \"{_name}\" \"Default\"", RawOutputParser.IsDefault);

    public static class RawOutputParser {
      public static Int32 GetVolume(String[] data) {
        if (data.Length == 0 || data.IsNullOrEmpty() || string.IsNullOrEmpty(data[0]))
          return 100;

        return (Int32) (float.Parse(data[0]) * 0.1f);
      }

      public static Boolean IsMuted(String[] data) {
        if (data.Length == 0 || data.IsNullOrEmpty() || string.IsNullOrEmpty(data[0]))
          return false;

        return data[0].Contains("Yes");
      }

      public static Boolean IsDefault(String[] data) {
        if (data.Length == 0 || data.IsNullOrEmpty() || string.IsNullOrEmpty(data[0]))
          return false;

        return data[0].Contains("Render") || data[0].Contains("Capture");
      }
    }
  }
}
