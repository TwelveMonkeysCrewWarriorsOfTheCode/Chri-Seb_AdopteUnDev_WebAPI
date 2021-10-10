CREATE TABLE [dbo].[NeededSkill]
(
	[NeededSkillID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ContractID] INT NOT NULL, 
    [SkillID] INT NOT NULL, 
    CONSTRAINT [FK_NeededSkill_ToContract] FOREIGN KEY ([ContractID]) REFERENCES [Contract]([ContractID]), 
    CONSTRAINT [FK_NeededSkill_ToSkill] FOREIGN KEY ([SkillID]) REFERENCES [Skill]([SkillID])
)
