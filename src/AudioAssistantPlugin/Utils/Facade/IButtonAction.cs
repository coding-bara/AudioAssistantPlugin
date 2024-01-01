namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public interface IButtonAction {
    Boolean OnButtonPress();

    String GetButtonText();

    BitmapImage GetButtonIcon();

    void OnButtonSetup();

    void OnButtonTeardown();

    void UpdateButtonIcon();

    void UpdateButton();
  }
}
