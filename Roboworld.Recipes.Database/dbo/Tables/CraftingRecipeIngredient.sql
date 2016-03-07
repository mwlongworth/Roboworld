CREATE TABLE [dbo].[CraftingRecipeIngredient] (
    [Id]				INT IDENTITY (1, 1) NOT NULL,
    [CraftingRecipeId]	INT NOT NULL,
    [ItemId]			INT NOT NULL,
    [Ordinal]			INT NOT NULL,
    [Quantity]			INT NOT NULL,
    [Catalyst]			BIT NOT NULL,
	CONSTRAINT [FK_CraftingRecipeIngredient_OutputId] FOREIGN KEY ([CraftingRecipeId]) REFERENCES [CraftingRecipe]([Id]),
	CONSTRAINT [FK_CraftingRecipeIngredient_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Item]([Id]),
    CONSTRAINT [PK_CraftingRecipeIngredient] PRIMARY KEY CLUSTERED ([Id] ASC)
);

