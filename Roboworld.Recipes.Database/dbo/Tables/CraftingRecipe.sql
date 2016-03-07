CREATE TABLE [dbo].[CraftingRecipe] (
    [Id]			INT IDENTITY (1, 1) NOT NULL,
    [ModId]			INT NOT NULL,
    [ProcessId]		INT NOT NULL,
    [OutputId]		INT NOT NULL,
    [Quantity]		INT NOT NULL,
    [Deleted]		BIT CONSTRAINT [DF_CraftingRecipe_Deleted2] DEFAULT ((0)) NOT NULL,
	CONSTRAINT [FK_CraftingRecipe_ModId] FOREIGN KEY ([ModId]) REFERENCES [Mod]([Id]),
	CONSTRAINT [FK_CraftingRecipe_OutputId] FOREIGN KEY ([OutputId]) REFERENCES [Item]([Id]),
    CONSTRAINT [PK_CraftingRecipe] PRIMARY KEY CLUSTERED ([Id] ASC)
);

