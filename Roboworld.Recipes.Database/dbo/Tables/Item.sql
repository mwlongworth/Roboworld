﻿CREATE TABLE [dbo].[Item] (
    [Id]		INT           IDENTITY (1, 1) NOT NULL,
    [Slug]		NVARCHAR (128) NOT NULL,
    [Name]		NVARCHAR (128) NOT NULL,
    [ModId]		INT           NOT NULL,
    [Deleted]	BIT           CONSTRAINT [DF_Item_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([Id] ASC)
);

