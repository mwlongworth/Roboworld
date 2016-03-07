CREATE TABLE [dbo].[Mod] (
    [Id]		INT				IDENTITY (1, 1) NOT NULL,
    [Slug]		NVARCHAR (128)	NOT NULL,
    [Name]		NVARCHAR (128)	NOT NULL,
    [Version]	NVARCHAR (64)	NOT NULL,
    [Deleted]	BIT           CONSTRAINT [DF_Mod_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Mod] PRIMARY KEY CLUSTERED ([Id] ASC)
);

