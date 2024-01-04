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
* Settings a non-configured input/output device as default will crash the plugin.
* Only two input/output device options are supported. (`outputA`/`outputB`, `inputA`/`inputB`)

# 3. How to setup?

1. Fire up Loupedeck.
2. Install a binary release of the plugin.
3. Restart Loupedeck. A default `config.json` has now been generated for you.
4. You can find the `config.json` in here: `%userprofile%\.loupedeck\AudioAssistant`.
5. Edit it to your needs, like described below:
   ```json5
    // entire, possible config.json
    {
      // Option A, needs to be specified
      "outputA": {
        "name": "Headset", // Use the name from "system" > "sound" > "volume mixer" > "input/output device".
        "type": "Headset" // Use one of these: "Speaker", "Headphones or "Headset".
      },
      // Option B, only needs to be specified if you also have another output device.
      "outputB": {
        "name": "Desk Speaker", // Use the name from "system" > "sound" > "volume mixer" > "input/output device".
        "type": "Speaker" // Use one of these: "Speaker", "Headphones or "Headset".
      },
      // Option A, needs to be specified
      "inputA": {
        "name": "Headset", // Use the name from "system" > "sound" > "volume mixer" > "input/output device".
        "type": "Headset" // Use one of these: "Headset" or "Microphone".
      },
      // Option B, only needs to be specified if you also have another input device.
      "inputB": {
        "name": "Desk Microphone", // Use the name from "system" > "sound" > "volume mixer" > "input/output device".
        "type": "Microphone" // Use one of these: "Headset" or "Microphone".
      },
      // Only needs to be specified if you want to control the sync rate with Windows.
      // The default is at "2500" milliseconds.
      // Reduce the value if you need it to be more accurate.
      // Increase it, if you want to reduce the system load.
      "monitoringRateInMS": 2500,
      // Only needs to be specified if you need the x32 version of SoundVolumeCommandLine.
      // The path has to be absolute.
      "exePath": "C:\\your\\path\\to\\svcl.exe",
    }
    ```
    ```json5
    // example config.json
    {
      "outputA": {
        "name": "Headset",
        "type": "Headset"
      },
      "outputB": {
        "name": "Desk Speaker",
        "type": "Speaker"
      },
      "inputA": {
        "name": "Headset",
        "type": "Headset"
      }
    }
    ```
6. Restart Loupedeck, the plugin is now ready for use.

# 4. How to support, give feedback or contribute?

* You found a bug?
I would love to hear about it [here](https://github.com/coding-bara/Loupedeck-AudioAssistantPlugin/issues/new/choose).

* You have a feature request?
Feel free to fork the repository and create some PR's.
