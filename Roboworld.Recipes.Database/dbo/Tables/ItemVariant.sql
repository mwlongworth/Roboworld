CREATE TABLE [dbo].[ItemVariant] (
    [Id]			INT				IDENTITY (1, 1) NOT NULL,
    [ItemId]		INT				NOT NULL,
    [Metadata]		INT				NOT NULL,
    [Tagtext]		NVARCHAR (MAX)	NULL,
    [DisplayName]	NVARCHAR (256)	NOT NULL,
    [Deleted]		BIT				CONSTRAINT [DF_ItemVariant_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ItemVariant] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_ItemVariant_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Item]([Id])
);

