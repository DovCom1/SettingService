namespace SettingsService.Application.DTOs;

public class SetEnemySettingsRequest
{
    public Guid UserId { get; set; }
    public Guid EnemyId { get; set; }
    public int NotificationSettings { get; set; } // 0,1,2
}