CREATE TABLE [dbo].[CraftingProcess] (
    [Id]			INT IDENTITY (1, 1) NOT NULL,
    [Name]			NVARCHAR (128)	NOT NULL,
    [Type]			INT NOT NULL,
    [ItemId]		INT NOT NULL,
    [Deleted]		BIT CONSTRAINT [DF_CraftingProcess_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CraftingProcess] PRIMARY KEY CLUSTERED ([Id] ASC)
);

