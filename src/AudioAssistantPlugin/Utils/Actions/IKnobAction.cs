namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public interface IKnobAction {
    Boolean OnKnobSetup();

    void OnKnobTeardown();

    Boolean OnKnobPress();

    Boolean OnKnobTurn(Int32 steps);

    String GetKnobValue();

    BitmapImage GetKnobIcon(PluginImageSize imageSize);

    void UpdateKnobIcon();

    void UpdateKnobText();

    void UpdateKnob();
  }
}
