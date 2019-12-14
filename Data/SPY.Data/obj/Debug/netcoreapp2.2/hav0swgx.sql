IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Articles] (
    [Id] int NOT NULL IDENTITY,
    [CategoryId] int NOT NULL,
    [Title] nvarchar(128) NOT NULL,
    [ImageUrl] nvarchar(128) NULL,
    [Content] nvarchar(max) NULL,
    [ViewCount] int NOT NULL,
    [Sort] int NOT NULL,
    [Author] nvarchar(64) NULL,
    [Source] nvarchar(128) NULL,
    [SeoTitle] nvarchar(128) NULL,
    [SeoKeyword] nvarchar(256) NULL,
    [SeoDescription] nvarchar(512) NULL,
    [AddManagerId] int NOT NULL,
    [AddTime] datetime2 NOT NULL,
    [ModifyManagerId] int NULL,
    [ModifyTime] datetime2 NULL,
    [IsTop] bit NOT NULL,
    [IsSlide] bit NOT NULL,
    [IsRed] bit NOT NULL,
    [IsPublish] bit NOT NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191025101602_init', N'2.2.6-servicing-10079');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191025102821_init1', N'2.2.6-servicing-10079');

GO

