using Microsoft.AspNetCore.Mvc;
using SettingsService.Application.Interfaces;
using SettingsService.Application.DTOs;

namespace SettingsService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SettingsController : ControllerBase
{
    private readonly ISettingsService _settingsService;

    public SettingsController(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    // GET api/settings/{userId}/enemies/{enemyId}
    [HttpGet("{userId:guid}/enemies/{enemyId:guid}")]
    public async Task<ActionResult> GetEnemySettings(Guid userId, Guid enemyId)
    {
        var setting = await _settingsService.GetEnemySettingAsync(userId, enemyId);

        if (setting == null)
            return Ok(new { notificationSettings = (int)Domain.Enums.NotificationSetting.AllNotification });

        return Ok(new { notificationSettings = (int)setting.NotificationSettings });
    }

    // POST api/settings/enemy
    [HttpPost("enemy")]
    public async Task<ActionResult> SetEnemySettings([FromBody] SetEnemySettingsRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var success = await _settingsService.SetEnemySettingAsync(
            request.UserId, request.EnemyId, request.NotificationSettings);

        return success ? Ok() : BadRequest("Failed to save settings.");
    }

    // POST api/settings/{userId}/setMicrophoneVolume
    [HttpPost("{userId:guid}/setMicrophoneVolume")]
    public async Task<ActionResult> SetMicrophoneVolume(Guid userId, [FromBody] SetMicrophoneVolumeRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var success = await _settingsService.SetMicrophoneVolumeAsync(
            userId, request.InterlocutorId, request.MicrophoneVolume);

        if (!success)
            return BadRequest("Failed to save volume.");

        var updated = await _settingsService.GetMicrophoneVideoSettingAsync(userId, request.InterlocutorId);
        return Ok(new { microphoneVolume = updated?.MicrophoneVolume ?? 100 });
    }

    // GET api/settings/{userId}/microphoneVolume/{interlocutorId}
    [HttpGet("{userId:guid}/microphoneVolume/{interlocutorId:guid}")]
    public async Task<ActionResult> GetMicrophoneVolume(Guid userId, Guid interlocutorId)
    {
        var setting = await _settingsService.GetMicrophoneVideoSettingAsync(userId, interlocutorId);
        var volume = setting?.MicrophoneVolume ?? 100;
        return Ok(new { microphoneVolume = volume });
    }

    // POST api/settings/{userId}/turnMicrophone/{interlocutorId}
    [HttpPost("{userId:guid}/turnMicrophone/{interlocutorId:guid}")]
    public async Task<ActionResult> TurnMicrophone(Guid userId, Guid interlocutorId, [FromBody] ToggleRequest request)
    {
        var success = await _settingsService.ToggleMicrophoneAsync(userId, interlocutorId, request.IsOn);
        if (!success)
            return BadRequest("Failed to toggle microphone.");

        var updated = await _settingsService.GetMicrophoneVideoSettingAsync(userId, interlocutorId);
        return Ok(new { isOn = updated?.IsMicrophoneOn ?? true });
    }

    // GET api/settings/{userId}/microphoneStatus/{interlocutorId}
    [HttpGet("{userId:guid}/microphoneStatus/{interlocutorId:guid}")]
    public async Task<ActionResult> GetMicrophoneStatus(Guid userId, Guid interlocutorId)
    {
        var setting = await _settingsService.GetMicrophoneVideoSettingAsync(userId, interlocutorId);
        var isOn = setting?.IsMicrophoneOn ?? true;
        return Ok(new { isOn });
    }

    // POST api/settings/{userId}/turnVideo/{interlocutorId}
    [HttpPost("{userId:guid}/turnVideo/{interlocutorId:guid}")]
    public async Task<ActionResult> TurnVideo(Guid userId, Guid interlocutorId, [FromBody] ToggleRequest request)
    {
        var success = await _settingsService.ToggleVideoAsync(userId, interlocutorId, request.IsOn);
        if (!success)
            return BadRequest("Failed to toggle video.");

        var updated = await _settingsService.GetMicrophoneVideoSettingAsync(userId, interlocutorId);
        return Ok(new { isOn = updated?.IsVideoOn ?? true });
    }

    // GET api/settings/{userId}/videoStatus/{interlocutorId}
    [HttpGet("{userId:guid}/videoStatus/{interlocutorId:guid}")]
    public async Task<ActionResult> GetVideoStatus(Guid userId, Guid interlocutorId)
    {
        var setting = await _settingsService.GetMicrophoneVideoSettingAsync(userId, interlocutorId);
        var isOn = setting?.IsVideoOn ?? true;
        return Ok(new { isOn });
    }
}