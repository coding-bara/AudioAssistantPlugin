namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public abstract class ActionBaseSwitch : PluginDynamicCommand {
    protected ActionBaseSwitch(String displayName, String description, String groupName) : base(displayName, description, groupName) { }

    protected abstract ActiveDevice ActiveDevice { get; }

    protected abstract Device DeviceOptionA { get; }
    protected abstract Device DeviceOptionB { get; }

    protected override Boolean OnLoad() {
      ActionImageChanged();

      return base.OnLoad();
    }

    protected override void RunCommand(String actionParameter) {
      if (DeviceOptionB.Name == "-")
        return;

      Device nextDevice;

      if (DeviceOptionA.IsDefault())
        nextDevice = DeviceOptionB;
      else
        nextDevice = DeviceOptionA;

      nextDevice.SetAsDefault();

      ActiveDevice.Instance = nextDevice;

      ActionImageChanged();
    }

    protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) {
      if (DeviceOptionB.Name == "-")
        return ActiveDevice.GetButtonIcon("NoOtherOptionsConfigured");

      return ActiveDevice.GetButtonIcon();
    }
  }
}
