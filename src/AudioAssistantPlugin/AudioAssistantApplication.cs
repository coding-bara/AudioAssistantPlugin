namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public class AudioAssistantApplication : ClientApplication {
    protected override String GetProcessName() => "";

    protected override String GetBundleName() => "";

    public override ClientApplicationStatus GetApplicationStatus() => ClientApplicationStatus.Unknown;
  }
}
