using SettingsService.Core.Interfaces;
using SettingsService.Core.Models;
using SettingsService.Core.DTOs;
using System.Threading.Tasks;
using System;

namespace SettingService.Managers;

public class SettingsManager : ISettingsService
{
    private readonly ISettingsService _repository;

    public SettingsManager(ISettingsService repository)
    {
        _repository = repository;
    }

    public async Task<EnemySetting?> GetEnemySettingAsync(Guid userId, Guid enemyId)
    {
        return await _repository.GetEnemySettingAsync(userId, enemyId);
    }

    public async Task<bool> SetEnemySettingAsync(Guid userId, Guid enemyId, int notificationSetting)
    {
        return await _repository.SetEnemySettingAsync(userId, enemyId, notificationSetting);
    }

    public async Task<MicrophoneVideoSetting?> GetMicrophoneVideoSettingAsync(Guid userId, Guid interlocutorId)
    {
        return await _repository.GetMicrophoneVideoSettingAsync(userId, interlocutorId);
    }

    public async Task<bool> SetMicrophoneVolumeAsync(Guid userId, Guid interlocutorId, int volume)
    {
        return await _repository.SetMicrophoneVolumeAsync(userId, interlocutorId, volume);
    }

    public async Task<bool> ToggleMicrophoneAsync(Guid userId, Guid interlocutorId, bool isOn)
    {
        return await _repository.ToggleMicrophoneAsync(userId, interlocutorId, isOn);
    }

    public async Task<bool> ToggleVideoAsync(Guid userId, Guid interlocutorId, bool isOn)
    {
        return await _repository.ToggleVideoAsync(userId, interlocutorId, isOn);
    }
}