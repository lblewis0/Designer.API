CREATE TABLE [dbo].[Folders]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(150) NOT NULL,
	[CreationDate] DATETIME NOT NULL,
	[LastUpdateDate] DATETIME NOT NULL,
	[ProjectId] INT NOT NULL,
	[ParentFolderId] INT,
	[IsEditable] BIT NOT NULL,
	[IsSelected] BIT NOT NULL,
	[IsExpanded] BIT NOT NULL,
	CONSTRAINT [PK_Folders] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Folders_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects]([Id])
)
