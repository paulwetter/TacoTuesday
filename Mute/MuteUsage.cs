using NAudio.CoreAudioApi;
using System;

public class Program
{
    static void Main()
    {
        VolumeControl volumeControl = new VolumeControl();
        volumeControl.OnMuteStateChanged += VolumeControl_OnMuteStateChanged;

        // Get the current mute status
        bool isMuted = volumeControl.GetMuteStatus();
        Console.WriteLine("Mute status: " + isMuted);

        // Set the mute status
        volumeControl.SetMuteStatus(true);

        Console.ReadLine();
    }

    private static void VolumeControl_OnMuteStateChanged(object sender, bool isMuted)
    {
        Console.WriteLine("Mute status changed: " + isMuted);
    }
}
