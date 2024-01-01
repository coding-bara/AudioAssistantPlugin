namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public abstract class BaseKnobAction : PluginDynamicAdjustment, IKnobAction {
    protected BaseKnobAction(String actionGroup, String actionName, String actionDescription) : base(actionName, actionDescription, actionGroup, true) { }

    protected override Boolean OnLoad() {
      OnKnobSetup();

      UpdateKnob();

      return base.OnLoad();
    }

    protected override Boolean OnUnload() {
      OnKnobTeardown();

      return base.OnLoad();
    }

    protected override void ApplyAdjustment(String _, Int32 steps) {
      if (OnKnobTurn(steps))
        UpdateKnobText();
    }

    protected override void RunCommand(String _) {
      if (OnKnobPress())
        UpdateKnobIcon();
    }

    public void UpdateKnobIcon() {
      ActionImageChanged();
    }

    public void UpdateKnobText() {
      AdjustmentValueChanged();
    }

    public void UpdateKnob() {
      UpdateKnobText();
      UpdateKnobIcon();
    }

    protected override String GetAdjustmentValue(String _) => GetKnobText();

    protected override BitmapImage GetAdjustmentImage(String _, PluginImageSize __) => GetKnobIcon();

    public virtual Boolean OnKnobPress() => false;

    public virtual Boolean OnKnobTurn(Int32 steps) => false;

    public virtual String GetKnobText() => default;

    public virtual BitmapImage GetKnobIcon() => default;

    public virtual void OnKnobSetup() { }

    public virtual void OnKnobTeardown() { }
  }
}
