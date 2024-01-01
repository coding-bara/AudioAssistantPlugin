namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public interface IKnobAction {
    void OnKnobSetup();

    void OnKnobTeardown();

    Boolean OnKnobPress();

    Boolean OnKnobTurn(Int32 steps);

    String GetKnobText();

    BitmapImage GetKnobIcon();

    void UpdateKnobIcon();

    void UpdateKnobText();

    void UpdateKnob();
  }
}
