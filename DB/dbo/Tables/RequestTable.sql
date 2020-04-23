CREATE TABLE [dbo].[RequestTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(300) NOT NULL, 
    [ProposalMessage] TEXT NOT NULL
)
