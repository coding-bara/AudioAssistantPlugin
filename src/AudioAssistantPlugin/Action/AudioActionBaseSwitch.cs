namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public abstract class AudioActionBaseSwitch : PluginDynamicCommand {
    protected AudioActionBaseSwitch(String displayName, String description, String groupName) : base(displayName, description, groupName) { }

    protected abstract AudioDeviceActive Current { get; }

    protected abstract AudioDevice OptionA { get; }
    protected abstract AudioDevice OptionB { get; }

    protected override Boolean OnLoad() {
      ActionImageChanged();

      return base.OnLoad();
    }

    protected override void RunCommand(String actionParameter) {
      if (OptionB.Name == "-")
        return;

      AudioDevice nextDevice;

      if (OptionA.IsDefault())
        nextDevice = OptionB;
      else
        nextDevice = OptionA;

      nextDevice.SetAsDefault();

      Current.Instance = nextDevice;

      ActionImageChanged();
    }

    protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) {
      if (OptionB.Name == "-")
        return Current.GetButtonIcon("NoOtherOptionsConfigured");

      return Current.GetButtonIcon();
    }
  }
}
