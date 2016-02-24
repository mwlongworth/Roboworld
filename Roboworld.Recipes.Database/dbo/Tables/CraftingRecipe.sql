CREATE TABLE [dbo].[CraftingRecipe] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [RecipeType] INT NOT NULL,
    [Deleted]    BIT CONSTRAINT [DF_CraftingRecipe_Deleted2] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CraftingRecipe2] PRIMARY KEY CLUSTERED ([Id] ASC)
);

