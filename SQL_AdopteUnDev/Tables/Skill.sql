CREATE TABLE [dbo].[Skill]
(
	[SkillID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(50) NULL, 
    [CategoryID] INT NOT NULL, 
    CONSTRAINT [FK_Skill_ToTable] FOREIGN KEY ([CategoryID]) REFERENCES [Category]([CategoryID])
)
