using SettingsService.Domain.Entities;
using SettingsService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using SettingsService.Infrastructure.Data;

namespace SettingsService.Infrastructure.Repositories;

public class SettingsRepository : ISettingsService
{
    private readonly ApplicationDbContext _context;

    public SettingsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EnemySetting?> GetEnemySettingAsync(Guid userId, Guid enemyId)
    {
        return await _context.EnemySettings
            .FirstOrDefaultAsync(e => e.UserId == userId && e.EnemyId == enemyId);
    }

    public async Task<bool> SetEnemySettingAsync(Guid userId, Guid enemyId, int notificationSetting)
    {
        var existing = await _context.EnemySettings
            .FirstOrDefaultAsync(e => e.UserId == userId && e.EnemyId == enemyId);

        if (existing == null)
        {
            _context.EnemySettings.Add(new EnemySetting
            {
                UserId = userId,
                EnemyId = enemyId,
                NotificationSettings = (Domain.Enums.NotificationSetting)notificationSetting
            });
        }
        else
        {
            existing.NotificationSettings = (Domain.Enums.NotificationSetting)notificationSetting;
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<MicrophoneVideoSetting?> GetMicrophoneVideoSettingAsync(Guid userId, Guid interlocutorId)
    {
        return await _context.MicrophoneVideoSettings
            .FirstOrDefaultAsync(m => m.UserId == userId && m.InterlocutorId == interlocutorId);
    }

    public async Task<bool> SetMicrophoneVolumeAsync(Guid userId, Guid interlocutorId, int volume)
    {
        var setting = await _context.MicrophoneVideoSettings
            .FirstOrDefaultAsync(m => m.UserId == userId && m.InterlocutorId == interlocutorId);

        if (setting == null)
        {
            _context.MicrophoneVideoSettings.Add(new MicrophoneVideoSetting
            {
                UserId = userId,
                InterlocutorId = interlocutorId,
                MicrophoneVolume = volume
            });
        }
        else
        {
            setting.MicrophoneVolume = volume;
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ToggleMicrophoneAsync(Guid userId, Guid interlocutorId, bool isOn)
    {
        var setting = await _context.MicrophoneVideoSettings
            .FirstOrDefaultAsync(m => m.UserId == userId && m.InterlocutorId == interlocutorId);

        if (setting == null)
        {
            _context.MicrophoneVideoSettings.Add(new MicrophoneVideoSetting
            {
                UserId = userId,
                InterlocutorId = interlocutorId,
                IsMicrophoneOn = isOn
            });
        }
        else
        {
            setting.IsMicrophoneOn = isOn;
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ToggleVideoAsync(Guid userId, Guid interlocutorId, bool isOn)
    {
        var setting = await _context.MicrophoneVideoSettings
            .FirstOrDefaultAsync(m => m.UserId == userId && m.InterlocutorId == interlocutorId);

        if (setting == null)
        {
            _context.MicrophoneVideoSettings.Add(new MicrophoneVideoSetting
            {
                UserId = userId,
                InterlocutorId = interlocutorId,
                IsVideoOn = isOn
            });
        }
        else
        {
            setting.IsVideoOn = isOn;
        }

        await _context.SaveChangesAsync();
        return true;
    }
}