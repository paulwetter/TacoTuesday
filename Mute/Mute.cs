using NAudio.CoreAudioApi;
using System;

public class VolumeControl
{
    private MMDeviceEnumerator deviceEnumerator;
    private MMDevice defaultDevice;

    public event EventHandler<bool> OnMuteStateChanged;

    public VolumeControl()
    {
        deviceEnumerator = new MMDeviceEnumerator();
        defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        defaultDevice.AudioEndpointVolume.OnVolumeNotification += AudioEndpointVolume_OnVolumeNotification;
    }

    public bool GetMuteStatus()
    {
        return defaultDevice.AudioEndpointVolume.Mute;
    }

    public void SetMuteStatus(bool isMuted)
    {
        defaultDevice.AudioEndpointVolume.Mute = isMuted;
    }

    private void AudioEndpointVolume_OnVolumeNotification(AudioVolumeNotificationData data)
    {
        bool isMuted = data.Muted;
        OnMuteStateChanged?.Invoke(this, isMuted);
    }
}

