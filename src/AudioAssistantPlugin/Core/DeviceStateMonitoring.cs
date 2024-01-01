namespace Loupedeck.AudioAssistantPlugin {
  using System;
  using System.Collections.Generic;
  using System.Threading;

  public class DeviceStateMonitoring {
    private readonly CancellationTokenSource _cts = new CancellationTokenSource();
    private readonly Thread _thread;
    private readonly List<Device> _devices;
    private readonly Int32 _monitoringRateInMs;

    public DeviceStateMonitoring(Config config, List<Device> devices) {
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

            try {
              if (device.IsDefault())
                device.Sync();
            } catch (Exception e) {
              Logger.Error(e, $"ThreadedMonitoring(device={device.Name}) failed with message: '{e.Message}'.");
            }
          }

          Thread.Sleep(_monitoringRateInMs);
        }
      };
    }
  }
}
