CREATE TABLE [dbo].[Components]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(150) NOT NULL,
	[CreationDate] DATETIME NOT NULL,
	[LastUpdateDate] DATETIME NOT NULL,
	[ProjectId] INT NOT NULL,
	[ParentFolderId] INT NOT NULL,
	[IsEditable] BIT NOT NULL,
	[IsSelected] BIT NOT NULL,
	[IsExpanded] BIT NOT NULL,
	CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Components_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects]([Id]),
	CONSTRAINT [FK_Components_Folder] FOREIGN KEY ([ParentFolderId]) REFERENCES [dbo].[Folders]([Id])
)
