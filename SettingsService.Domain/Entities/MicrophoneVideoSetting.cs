using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SettingsService.Domain.Entities;

[Table("MicrophoneVideoSettings")]
public class MicrophoneVideoSetting
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid UserId { get; set; }

    [Required]
    public Guid InterlocutorId { get; set; }

    [Range(0, 200)]
    public int MicrophoneVolume { get; set; } = 100;

    public bool IsMicrophoneOn { get; set; } = true;
    public bool IsVideoOn { get; set; } = true;
}