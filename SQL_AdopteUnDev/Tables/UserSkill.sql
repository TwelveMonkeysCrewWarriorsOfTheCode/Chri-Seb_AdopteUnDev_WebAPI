CREATE TABLE [dbo].[UserSkill]
(
	[UserSkilID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL, 
    [SkillID] INT NOT NULL, 
    CONSTRAINT [FK_UserSkill_ToUser] FOREIGN KEY ([UserID]) REFERENCES [User]([UserID]), 
    CONSTRAINT [FK_UserSkill_ToSkill] FOREIGN KEY ([SkillID]) REFERENCES [Skill]([SkillID])
)
