namespace SettingsService.Application.DTOs;

public class SetMicrophoneVolumeRequest
{
    public Guid InterlocutorId { get; set; }
    public int MicrophoneVolume { get; set; } // 0–200
}