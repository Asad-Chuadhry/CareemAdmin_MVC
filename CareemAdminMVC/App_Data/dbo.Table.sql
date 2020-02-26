CREATE TABLE [dbo].[User]
(
	[UserID] INT NOT NULL PRIMARY KEY, 
    [Username] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [FullName] VARCHAR(100) NOT NULL, 
    [EmailID] VARCHAR(128) NULL
)
