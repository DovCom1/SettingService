using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SettingsService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnemySettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    EnemyId = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationSettings = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemySettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MicrophoneVideoSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    InterlocutorId = table.Column<Guid>(type: "uuid", nullable: false),
                    MicrophoneVolume = table.Column<int>(type: "integer", nullable: false),
                    IsMicrophoneOn = table.Column<bool>(type: "boolean", nullable: false),
                    IsVideoOn = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MicrophoneVideoSettings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnemySettings_UserId_EnemyId",
                table: "EnemySettings",
                columns: new[] { "UserId", "EnemyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MicrophoneVideoSettings_UserId_InterlocutorId",
                table: "MicrophoneVideoSettings",
                columns: new[] { "UserId", "InterlocutorId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnemySettings");

            migrationBuilder.DropTable(
                name: "MicrophoneVideoSettings");
        }
    }
}
