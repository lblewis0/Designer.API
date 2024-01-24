/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[Users] ([Firstname], [Lastname], [Email], [Username], [Password], [UserRole], [ActiveProjectId])
VALUES ('Louis', 'Boeckmans', 'louis.boeckmans@outlook.com', 'LouisB', 'designer', 'Admin', 0);

INSERT INTO [dbo].[Projects] ([Name], [CreationDate], [LastUpdateDate], [UserId])
VALUES ('Template', GETDATE(), GETDATE(), 1),
       ('Models', GETDATE(), GETDATE(), 1);


INSERT INTO [dbo].[Folders] ([Name], [CreationDate], [LastUpdateDate], [ProjectId], [ParentFolderId], [IsEditable], [IsSelected], [IsExpanded])
VALUES ('Template', GETDATE(), GETDATE(), 1, 0, 'false', 'false', 'false'),
       ('Template 0.1', GETDATE(), GETDATE(), 1, 1, 'false', 'false', 'false'),
       ('Template 0.2', GETDATE(), GETDATE(), 1, 1, 'false', 'false', 'false'),
       ('Template 0.1.1', GETDATE(), GETDATE(), 1, 2, 'false', 'false', 'false'),
       ('Template 0.2.1', GETDATE(), GETDATE(), 1, 3, 'false', 'false', 'false'),
       ('Model', GETDATE(), GETDATE(), 2, 0, 'false', 'false', 'false'),
       ('Model 0.1', GETDATE(), GETDATE(), 2, 6, 'false', 'false', 'false'),
       ('Model 0.2', GETDATE(), GETDATE(), 2, 6, 'false', 'false', 'false'),
       ('Model 0.1.1', GETDATE(), GETDATE(), 2, 7, 'false', 'false', 'false'),
       ('Model 0.2.1', GETDATE(), GETDATE(), 2, 8, 'false', 'false', 'false');
