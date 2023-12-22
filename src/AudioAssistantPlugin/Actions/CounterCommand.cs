namespace Loupedeck.AudioAssistantPlugin {
  using System;

  // This class implements an example command that counts button presses.

  public class CounterCommand : PluginDynamicCommand {
    private Int32 _counter;

    // Initializes the command class.
    public CounterCommand()
      : base("Press Counter", "Counts button presses", "Commands") { }

    // This method is called when the user executes the command.
    protected override void RunCommand(String actionParameter) {
      _counter++;
      ActionImageChanged(); // Notify the Loupedeck service that the command display name and/or image has changed.
      PluginLog.Info($"Counter value is {_counter}"); // Write the current counter value to the log file.
    }

    // This method is called when Loupedeck needs to show the command on the console or the UI.
    protected override String GetCommandDisplayName(String actionParameter, PluginImageSize imageSize) => $"Press Counter{Environment.NewLine}{_counter}";
  }
}
