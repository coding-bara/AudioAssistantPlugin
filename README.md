# 1. Table of content
- [1. Table of content](#1-table-of-content)
- [2. What is this plugin about?](#2-what-is-this-plugin-about)
- [3. How to setup?](#3-how-to-setup)
- [4. How to support, give feedback or contribute?](#4-how-to-support-give-feedback-or-contribute)

# 2. What is this plugin about?

With this plugin you can control your audio input and output:

* You can adjust the device volume.
* You can mute or unmute the device.
* You can switch between device option a and b.

It uses [SoundVolumeCommandLine](https://www.nirsoft.net/utils/sound_volume_command_line.html) in version 1.25 to implement these features.
SoundVolumeCommandLine is shipped within the plugin in the x64 version.
If you need the x32 version, you can download it [here](https://www.nirsoft.net/utils/svcl.zip).

**Limitations**:

* There is only a Windows version of the plugin.
* There are no plausibility checks, so expect Loupedesk.exe to crash if you accidentally configure it incorrectly.

# 3. How to setup?

1. Install a binary release of the plugin.
2. Fire up Loupedeck. A default `config.json` has now been generated for you.
3. You can find the `config.json` here: `%userprofile%\.loupedeck\audio-assistant`.
4. Edit it to your needs, like described in here:
    ```json5
    {
      "outputA": {
        // Use the name from "system" > "sound" > "volume mixer" > "input/output device".
        "name": "Headset Max",
        // Use one of these for an input device: "Headset", "Microphone" or "-" and use one of these for an output device: "Headset", "Headphones", "Speaker" or  "-".
        // You always need "outputA" and "inputA" to be configured.
        // Both, "outputB" and "inputB" are optional, but both have to be configured with a "-".
        "type": "Headset"
      },
      "outputB": {
        "name": "Desktop Speaker",
        "type": "Speaker"
      },
      "inputA": {
        "name": "Headset Max",
        "type": "Headset"
      },
      "inputB": {
        "name": "-",
        "type": "-"
      },
      // The default path for x64 is ".\\Resources\\Executables\\svcl.exe" as this version is already shipped with the binaries.
      // If you need the x32 version, you either replace the "svcl.exe" or adjust the path to your download.
      "executablePath": ".\\Resources\\Executables\\svcl.exe",
      // The default value is "1000".
      // It means, that the plugins syncs with the Windows audio settings every 1000 milliseconds.
      // Reduce the value if you need it to be more accurate.
      // Increase it, if you want to reduce the system load.
      "monitoringRateInMS": 1000
    }
    ```
5. Restart Loupedeck. You can now use the plugin.

# 4. How to support, give feedback or contribute?

* You found a bug?
I would love to hear about it [here](https://github.com/coding-bara/AudioAssistantPlugin/issues/new/choose).

* You have a feature request?
Feel free to fork the repository and create some PR's.
