CREATE TABLE [dbo].[RecipeItemLink] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [CraftingRecipeId] INT NOT NULL,
    [ContentType]      INT NOT NULL,
    [ItemId]           INT NOT NULL,
    CONSTRAINT [PK_RecipeItemLink] PRIMARY KEY CLUSTERED ([Id] ASC)
);

