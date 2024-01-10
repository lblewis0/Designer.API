﻿CREATE TABLE [dbo].[Projects]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(150) NOT NULL,
	[CreationDate] DATETIME NOT NULL,
	[LastUpdateDate] DATETIME NOT NULL,
	[UserId] INT NOT NULL,
	CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Projects_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([Id])

)
