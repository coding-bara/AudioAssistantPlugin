namespace Loupedeck.AudioAssistantPlugin {
  using System;

  internal static class Logger {
    private static PluginLogFile _logFile;

    public static void Init(PluginLogFile logFile) {
      logFile.CheckNullArgument(nameof(logFile));
      _logFile = logFile;
    }

    public static void Verbose(String text) => _logFile?.Verbose(text);

    public static void Verbose(Exception ex, String text) => _logFile?.Verbose(ex, text);

    public static void Info(String text) => _logFile?.Info(text);

    public static void Info(Exception ex, String text) => _logFile?.Info(ex, text);

    public static void Warning(String text) => _logFile?.Warning(text);

    public static void Warning(Exception ex, String text) => _logFile?.Warning(ex, text);

    public static void Error(String text) => _logFile?.Error(text);

    public static void Error(Exception ex, String text) => _logFile?.Error(ex, text);
  }
}
