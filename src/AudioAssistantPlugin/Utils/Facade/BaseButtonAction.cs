namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public abstract class BaseButtonAction : PluginDynamicCommand, IButtonAction {
    protected BaseButtonAction(String actionGroup, String actionName, String actionDescription) : base(actionName, actionDescription, actionGroup) { }

    protected override Boolean OnLoad() {
      OnButtonSetup();

      UpdateButtonIcon();

      return base.OnLoad();
    }

    protected override Boolean OnUnload() {
      OnButtonTeardown();

      return base.OnLoad();
    }

    protected override void RunCommand(String _) {
      if (OnButtonPress())
        UpdateButtonIcon();
    }

    public void UpdateButtonIcon() {
      ActionImageChanged();
    }

    public void UpdateButton() {
      UpdateButtonIcon();
    }

    protected override BitmapImage GetCommandImage(String _, PluginImageSize __) => GetButtonIcon();

    protected override String GetCommandDisplayName(String actionParameter, PluginImageSize imageSize) => GetButtonText();

    public virtual Boolean OnButtonPress() => false;

    public virtual String GetButtonText() => default;

    public virtual BitmapImage GetButtonIcon() => default;

    public virtual void OnButtonSetup() { }

    public virtual void OnButtonTeardown() { }
  }
}
