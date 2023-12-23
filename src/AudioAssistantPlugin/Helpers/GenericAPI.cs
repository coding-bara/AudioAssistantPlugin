namespace Loupedeck.AudioAssistantPlugin {
  using System;
  using System.Diagnostics;

  public class GenericAPI {
    private readonly String _executablePath;

    protected GenericAPI(String executablePath) {
      _executablePath = executablePath;
    }

    protected delegate T ParseRawOutputCallback<T>(String[] rawOutput);

    protected T RunCommand<T>(String command, ParseRawOutputCallback<T> parseRawOutputCallback) {
      T parsedOutput = default;

      try {
        var process = new Process {
          StartInfo = new ProcessStartInfo(_executablePath, command) {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
          }
        };
        process.Start();

        var rawOutput = process.StandardOutput.ReadToEnd().Split().RemoveAll(string.IsNullOrWhiteSpace);

        process.WaitForExit();

        #if LOGGING
        var exitCode = process.ExitCode;
        #endif

        process.Close();

        parsedOutput = parseRawOutputCallback.Invoke(rawOutput);

        #if LOGGING
        Logger.Verbose($"'{_executablePath} {command}' succeeded with output: {parsedOutput}. ({exitCode})");
        #endif
      } catch (Exception e) {
        Logger.Error(e, $"'{_executablePath} {command}' failed with message: '{e.Message}'.");
      }

      return parsedOutput;
    }

    protected void RunCommand(String command) {
      try {
        var process = new Process {
          StartInfo = new ProcessStartInfo(_executablePath, command) {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
          }
        };
        process.Start();
        process.WaitForExit();

        #if LOGGING
        var exitCode = process.ExitCode;
        #endif

        process.Close();
        #if LOGGING
        Logger.Verbose($"'{_executablePath} {command}' succeeded. ({exitCode})");
        #endif
      } catch (Exception e) {
        Logger.Error(e, $"'{_executablePath} {command}' failed with message: '{e.Message}'.");
      }
    }
  }
}
