namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public abstract class BaseDeviceSwitchButton : BaseButtonAction {
    protected BaseDeviceSwitchButton(String actionGroup, String actionName, String actionDescription) : base(actionGroup, actionName, actionDescription) { }

    protected abstract ActiveDevice ActiveDevice { get; }

    protected abstract Device DeviceOptionA { get; }
    protected abstract Device DeviceOptionB { get; }

    public override Boolean OnButtonPress() {
      if (DeviceOptionB.Name == "-")
        return false;

      Device nextDevice;

      if (DeviceOptionA.IsDefault())
        nextDevice = DeviceOptionB;
      else
        nextDevice = DeviceOptionA;

      nextDevice.SetAsDefault();

      ActiveDevice.I = nextDevice;

      return true;
    }

    public override BitmapImage GetButtonIcon() => ActiveDevice.I.GetButtonIcon(
      ActiveDevice.Category,
      DeviceOptionB.Name == "-"
        ? "NoOtherOptionsConfigured"
        : default
    );
  }
}
