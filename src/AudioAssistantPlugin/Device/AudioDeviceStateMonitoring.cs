namespace Loupedeck.AudioAssistantPlugin {
  using System;
  using System.Collections.Generic;
  using System.Threading;

  public class AudioDeviceStateMonitoring {
    private readonly CancellationTokenSource _cts = new CancellationTokenSource();
    private readonly Thread _thread;
    private readonly List<AudioDevice> _devices;
    private readonly Int32 _monitoringRateInMs;

    public AudioDeviceStateMonitoring(Config config, List<AudioDevice> devices) {
      _monitoringRateInMs = config.MonitoringRateInMS;
      _devices = devices;

      _thread = new Thread(ThreadedMonitoring()) {
        IsBackground = true
      };
    }

    public void Start() {
      _thread.Start();
    }

    public void Stop() {
      if (_cts != null) {
        _cts.Cancel();
        _cts.Dispose();
      }

      _thread?.Join();
    }

    private ThreadStart ThreadedMonitoring() {
      return () => {
        while (!_cts.Token.IsCancellationRequested) {
          foreach (var device in _devices) {
            if (device.Name == "-")
              continue;

            ThreadedDeviceMonitoring(device.Name, device.API, device.State);
          }

          Thread.Sleep(_monitoringRateInMs);
        }
      };
    }

    private void ThreadedDeviceMonitoring(String name, AudioDeviceAPI api, AudioDeviceState state) {
      try {
        if (api.IsDefault()) {
          state.IsMuted = api.IsMuted();
          state.Volume = api.GetVolume();
        }
      } catch (Exception e) {
        Logger.Error(e, $"ThreadedDeviceMonitoring(device={name}) failed with message: '{e.Message}'.");
      }
    }
  }
}
