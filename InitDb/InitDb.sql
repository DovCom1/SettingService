CREATE TABLE "EnemySettings" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "UserId" UUID NOT NULL,
    "EnemyId" UUID NOT NULL,
    "NotificationSettings" SMALLINT NOT NULL CHECK ("NotificationSettings" IN (0, 1, 2)),
    
    CONSTRAINT "UQ_EnemySettings_UserId_EnemyId" 
        UNIQUE ("UserId", "EnemyId")
);

CREATE INDEX "IX_EnemySettings_UserId" ON "EnemySettings" ("UserId");
CREATE INDEX "IX_EnemySettings_EnemyId" ON "EnemySettings" ("EnemyId");


CREATE TABLE "MicrophoneVideoSettings" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "UserId" UUID NOT NULL,
    "InterlocutorId" UUID NOT NULL,
    "MicrophoneVolume" SMALLINT NOT NULL DEFAULT 100 CHECK ("MicrophoneVolume" BETWEEN 0 AND 200),
    "IsMicrophoneOn" BOOLEAN NOT NULL DEFAULT TRUE,
    "IsVideoOn" BOOLEAN NOT NULL DEFAULT TRUE,

    CONSTRAINT "UQ_MicrophoneVideoSettings_UserId_InterlocutorId" 
        UNIQUE ("UserId", "InterlocutorId")
);

CREATE INDEX "IX_MicrophoneVideoSettings_UserId" ON "MicrophoneVideoSettings" ("UserId");
CREATE INDEX "IX_MicrophoneVideoSettings_InterlocutorId" ON "MicrophoneVideoSettings" ("InterlocutorId");