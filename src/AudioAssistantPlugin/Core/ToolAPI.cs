namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public class ToolAPI : GenericAPI {
    public ToolAPI(String exePath) : base(exePath) { }

    public Int32 GetVolume(String deviceName) => RunCommand($"/GetColumnValue \"{deviceName}\" \"Volume Percent\"", RawOutputParser.GetVolume);

    public void ChangeVolume(String deviceName, Int32 volumeStep) => RunCommand($"/ChangeVolume \"{deviceName}\" {volumeStep}");

    public void Unmute(String deviceName) => RunCommand($"/Unmute \"{deviceName}\"");

    public void Mute(String deviceName) => RunCommand($"/Mute \"{deviceName}\"");

    public Boolean IsMuted(String deviceName) => RunCommand($"/GetColumnValue \"{deviceName}\" \"Muted\"", RawOutputParser.IsMuted);

    public void SetAsDefault(String deviceName) => RunCommand($"/SetDefault \"{deviceName}\" \"all\"");

    public Boolean IsDefault(String deviceName) => RunCommand($"/GetColumnValue \"{deviceName}\" \"Default\"", RawOutputParser.IsDefault);

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
