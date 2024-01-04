namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public abstract class ASwitchDeviceButton : BaseButton {
    protected ASwitchDeviceButton(String actionGroup, String actionName, String actionDescription) : base(actionGroup, actionName, actionDescription) { }

    protected abstract ActiveDevice ActiveDevice { get; }

    protected abstract Device DeviceOptionA { get; }
    protected abstract Device DeviceOptionB { get; }

    public override Boolean OnButtonSetup() => DeviceOptionB.Name != "-";

    public override Boolean OnButtonPress() {
      Device nextDevice;

      if (DeviceOptionA.IsDefault())
        nextDevice = DeviceOptionB;
      else
        nextDevice = DeviceOptionA;

      nextDevice.SetAsDefault();

      ActiveDevice.I = nextDevice;

      return true;
    }

    public override BitmapImage GetButtonIcon(PluginImageSize _) => ActiveDevice.I.GetButtonIcon(GetIconBasePath(80), ActiveDevice.Category);
  }
}
