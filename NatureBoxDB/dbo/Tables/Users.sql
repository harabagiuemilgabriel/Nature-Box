CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserFirstName] NVARCHAR(50) NOT NULL, 
    [UserLastName] NVARCHAR(50) NOT NULL, 
    [UserEmail] NCHAR(10) NOT NULL, 
    [UserConfirmEmail] BIT NOT NULL, 
    [UserToken] NVARCHAR(50) NOT NULL, 
    [UserPassword] NVARCHAR(50) NOT NULL
)
