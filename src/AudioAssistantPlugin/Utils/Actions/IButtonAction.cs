namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public interface IButtonAction {
    Boolean OnButtonPress();

    String GetButtonValue();

    BitmapImage GetButtonIcon(PluginImageSize imageSize);

    Boolean OnButtonSetup();

    void OnButtonTeardown();

    void UpdateButtonIcon();

    void UpdateButton();
  }
}
