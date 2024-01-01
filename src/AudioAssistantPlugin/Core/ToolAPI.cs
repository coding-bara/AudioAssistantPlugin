namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public class ToolAPI : GenericAPI {
    public ToolAPI(String exePath) : base(exePath) { }

    public Int32 GetVolume(String name) => RunCommand($"/GetColumnValue \"{name}\" \"Volume Percent\"", RawOutputParser.GetVolume);

    public void ChangeVolume(String name, Int32 volumeStep) => RunCommand($"/ChangeVolume \"{name}\" {volumeStep}");

    public void Unmute(String name) => RunCommand($"/Unmute \"{name}\"");

    public void Mute(String name) => RunCommand($"/Mute \"{name}\"");

    public Boolean IsMuted(String name) => RunCommand($"/GetColumnValue \"{name}\" \"Muted\"", RawOutputParser.IsMuted);

    public void SetAsDefault(String name) => RunCommand($"/SetDefault \"{name}\" \"all\"");

    public Boolean IsDefault(String name) => RunCommand($"/GetColumnValue \"{name}\" \"Default\"", RawOutputParser.IsDefault);

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
