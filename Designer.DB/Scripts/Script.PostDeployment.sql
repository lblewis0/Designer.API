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
VALUES ('Louis', 'Boeckmans', 'louis.boeckmans@outlook.com', 'LouisB', 'designer', 'Admin', 1);

INSERT INTO [dbo].[Projects] ([Name], [CreationDate], [LastUpdateDate], [UserId])
VALUES ('Template', GETDATE(), GETDATE(), 1),
       ('Models', GETDATE(), GETDATE(), 1);


INSERT INTO [dbo].[Folders] ([Name], [CreationDate], [LastUpdateDate], [ProjectId], [ParentFolderId], [IsEditable], [IsSelected], [IsExpanded])
VALUES ('Template', GETDATE(), GETDATE(), 1, 0, 'false', 'false', 'false'), /* 1 */
       ('Folder 1', GETDATE(), GETDATE(), 1, 1, 'false', 'false', 'false'), /* 2 */
       ('Folder 2', GETDATE(), GETDATE(), 1, 1, 'false', 'false', 'false'), /* 3 */
       ('Folder 1.1', GETDATE(), GETDATE(), 1, 2, 'false', 'false', 'false'), /* 4 */
       ('Folder 2.1', GETDATE(), GETDATE(), 1, 3, 'false', 'false', 'false'), /* 5 */
       ('Models', GETDATE(), GETDATE(), 2, 0, 'false', 'false', 'false'), /* 6 */
       ('Folder 1', GETDATE(), GETDATE(), 2, 6, 'false', 'false', 'false'), /* 7 */
       ('Folder 2', GETDATE(), GETDATE(), 2, 6, 'false', 'false', 'false'), /* 8 */
       ('Folder 1.1', GETDATE(), GETDATE(), 2, 7, 'false', 'false', 'false'), /* 9 */
       ('Folder 2.1', GETDATE(), GETDATE(), 2, 8, 'false', 'false', 'false'); /* 10 */

INSERT INTO [dbo].[Components] ([Name], [CreationDate], [LastUpdateDate], [ProjectId], [ParentFolderId], [IsEditable], [IsSelected], [IsExpanded])
VALUES ('Component 1', GETDATE(), GETDATE(), 1, 2, 'false', 'false', 'false'), /* 1 */
       ('Component 2', GETDATE(), GETDATE(), 1, 3, 'false', 'false', 'false'), /* 2 */
       ('Component 1.1', GETDATE(), GETDATE(), 1, 4, 'false', 'false', 'false'), /* 3 */
       ('Component 2.1', GETDATE(), GETDATE(), 1, 5, 'false', 'false', 'false'), /* 4 */
       ('Component 1', GETDATE(), GETDATE(), 2, 7, 'false', 'false', 'false'), /* 5 */
       ('Component 2', GETDATE(), GETDATE(), 2, 8, 'false', 'false', 'false'), /* 6 */
       ('Component 1.1', GETDATE(), GETDATE(), 2, 9, 'false', 'false', 'false'), /* 7 */
       ('Component 2.1', GETDATE(), GETDATE(), 2, 10, 'false', 'false', 'false'); /* 8 */
