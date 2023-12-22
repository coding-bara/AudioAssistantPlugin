namespace Loupedeck.AudioAssistantPlugin {
  using System;

  public class AudioAssistantPlugin : Plugin {
    public override Boolean UsesApplicationApiOnly => true;
    public override Boolean HasNoApplication => true;

    public AudioAssistantPlugin() {
      PluginLog.Init(Log);
      PluginResources.Init(Assembly);
    }

    public override void Load() { }

    public override void Unload() { }
  }
}
