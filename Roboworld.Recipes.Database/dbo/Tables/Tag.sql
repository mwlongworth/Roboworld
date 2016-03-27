CREATE TABLE [dbo].[Tag] (
    [Id]		INT				IDENTITY (1, 1) NOT NULL,
    [TagText]		NVARCHAR (MAX)	NOT NULL,
    [Deleted]	BIT           CONSTRAINT [DF_Tag_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED ([Id] ASC)
);

