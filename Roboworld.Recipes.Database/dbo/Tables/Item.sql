CREATE TABLE [dbo].[Item] (
    [Id]		INT				IDENTITY (1, 1) NOT NULL,
    [ModId]		INT				NOT NULL,
    [Slug]		NVARCHAR (128)	NOT NULL,
    [HasBlock]	BIT				NOT NULL,
    [LegacyId]	INT				NULL,
    [Deleted]	BIT				CONSTRAINT [DF_Item_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Item_ModId] FOREIGN KEY ([ModId]) REFERENCES [Mod]([Id])
);

