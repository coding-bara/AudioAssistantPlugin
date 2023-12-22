namespace Loupedeck.AudioAssistantPlugin {
  using System;

  // This class implements an example adjustment that counts the rotation ticks of a dial.

  public class CounterAdjustment : PluginDynamicAdjustment {
    // This variable holds the current value of the counter.
    private Int32 _counter;

    // Initializes the adjustment class.
    // When `hasReset` is set to true, a reset command is automatically created for this adjustment.
    public CounterAdjustment()
      : base("Tick Counter", "Counts rotation ticks", "Adjustments", true) { }

    // This method is called when the adjustment is executed.
    protected override void ApplyAdjustment(String actionParameter, Int32 diff) {
      _counter += diff; // Increase or decrease the counter by the number of ticks.
      AdjustmentValueChanged(); // Notify the Loupedeck service that the adjustment value has changed.
    }

    // This method is called when the reset command related to the adjustment is executed.
    protected override void RunCommand(String actionParameter) {
      _counter = 0; // Reset the counter.
      AdjustmentValueChanged(); // Notify the Loupedeck service that the adjustment value has changed.
    }

    // Returns the adjustment value that is shown next to the dial.
    protected override String GetAdjustmentValue(String actionParameter) => _counter.ToString();
  }
}
