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

