CREATE TABLE [dbo].[Item] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    [Mod]     INT           NOT NULL,
    [Deleted] BIT           CONSTRAINT [DF_CraftingRecipe_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([Id] ASC)
);

