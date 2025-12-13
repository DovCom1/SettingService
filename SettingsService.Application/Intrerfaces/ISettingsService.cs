using SettingsService.Application.DTOs;
using SettingsService.Domain.Entities;

namespace SettingsService.Application.Interfaces;

public interface ISettingsService
{
    Task<EnemySetting?> GetEnemySettingAsync(Guid userId, Guid enemyId);
    Task<bool> SetEnemySettingAsync(Guid userId, Guid enemyId, int notificationSetting);

    Task<MicrophoneVideoSetting?> GetMicrophoneVideoSettingAsync(Guid userId, Guid interlocutorId);
    Task<bool> SetMicrophoneVolumeAsync(Guid userId, Guid interlocutorId, int volume);
    Task<bool> ToggleMicrophoneAsync(Guid userId, Guid interlocutorId, bool isOn);
    Task<bool> ToggleVideoAsync(Guid userId, Guid interlocutorId, bool isOn);
}