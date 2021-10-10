CREATE TABLE [dbo].[Contract]
(
	[ContractID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(250) NOT NULL, 
    [Price] INT NOT NULL, 
    [DeadLine] DATE NOT NULL, 
    [ClientID] INT NOT NULL, 
    [DevID] INT NULL, 
    CONSTRAINT [FK_Contract_ToClient] FOREIGN KEY ([ClientID]) REFERENCES [User]([UserID]),
    CONSTRAINT [FK_Contract_ToDev] FOREIGN KEY ([DevID]) REFERENCES [User]([UserID])
)
