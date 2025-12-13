using Microsoft.EntityFrameworkCore;
using SettingsService.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SettingsService.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }

    public DbSet<EnemySetting> EnemySettings => Set<EnemySetting>();
    public DbSet<MicrophoneVideoSetting> MicrophoneVideoSettings => Set<MicrophoneVideoSetting>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnemySetting>()
            .HasIndex(e => new { e.UserId, e.EnemyId })
            .IsUnique();

        modelBuilder.Entity<MicrophoneVideoSetting>()
            .HasIndex(m => new { m.UserId, m.InterlocutorId })
            .IsUnique();
    }
}