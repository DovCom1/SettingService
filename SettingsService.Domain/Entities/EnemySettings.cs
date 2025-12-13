using SettingsService.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SettingsService.Domain.Entities;

[Table("EnemySettings")]
public class EnemySetting
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid UserId { get; set; }

    [Required]
    public Guid EnemyId { get; set; }

    [Required]
    public NotificationSetting NotificationSettings { get; set; }
}