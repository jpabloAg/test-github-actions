CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220912063523_FirstMigration') THEN
    CREATE TABLE "WeatherForecasts" (
        "Id" text NOT NULL,
        "Date" timestamp with time zone NOT NULL,
        "TemperatureC" integer NOT NULL,
        "Summary" text NULL,
        CONSTRAINT "PK_WeatherForecasts" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220912063523_FirstMigration') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220912063523_FirstMigration', '7.0.0-preview.7.22376.2');
    END IF;
END $EF$;
COMMIT;

