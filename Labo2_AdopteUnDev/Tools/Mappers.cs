
using API = Labo2_AdopteUnDev.Models;

namespace Labo2_AdopteUnDev.Tools
{
	public static class Mappers
	{
		public static API.User ToAPI(this DAL.Models.LoginUser user)
		{
			if (user != null)
			{
				return new API.User
				{
					UserID = user.UserID,
					Email = user.Email,
					//Password = user.Password
					IsClient = user.IsClient
				};
			}
			return null;
		}

		public static API.UserDev ToAPI2(this DAL.Models.User user)
		{
			return new API.UserDev
			{
				UserID = user.UserID,
				Name = user.Name,
				Email = user.Email,
				Telephone = user.Telephone
			};
		}
		public static API.Contract ToAPIc(this DAL.Models.Contract contract)
		{
			if (contract != null)
			{
				return new API.Contract
				{
					ContractID = contract.ContractID,
					Description = contract.Description,
					Price = contract.Price,
					DeadLine = contract.DeadLine,
					ClientId = contract.ClientId,
					DevId = contract.DevId,
					UName = contract.UName
				};
			}
			return null;
		}
		public static DAL.Models.AddContract ToAPIc2(this API.AddContract contract)
		{
			return new DAL.Models.AddContract
			{
				Description = contract.Description,
				Price = contract.Price,
				DeadLine = contract.DeadLine,
				ClientId = contract.ClientId
			};
		}
		public static DAL.Models.PickContract ToAPICPC(this API.PickContract contract)
		{
			return new DAL.Models.PickContract
			{
				ContractID = contract.ContractID,
				DevId = contract.DevId
			};
		}
		public static DAL.Models.AddSkill ToAPICS2(this API.AddSkill skill)
		{
			return new DAL.Models.AddSkill
			{
				ContractID = skill.ContractID,
				SkillID = skill.SkillID
			};
		}
		public static API.Skill ToAPICCS(this DAL.Models.Skill skill)
		{
			if (skill != null)
			{
				return new API.Skill
				{
					SkillID = skill.SkillID,
					Name = skill.Name,
					Description = skill.Description,
					CName = skill.CName
				};
			}
			return null;
		}
		public static API.SkillCID ToAPICS(this DAL.Models.SkillCID skill)
		{
			if (skill != null)
			{
				return new API.SkillCID
				{
					NeededSkillsID = skill.NeededSkillsID,
					ContractID = skill.ContractID,
					SkillID = skill.SkillID
				};
			}
			return null;
		}
		public static DAL.Models.AddUserSkill ToAPICSk1(this API.AddUserSkill skill)
		{
			return new DAL.Models.AddUserSkill
			{
				UserID = skill.UserID,
				SkillID = skill.SkillID
			};
		}
		public static API.UserSkills ToAPICSk2(this DAL.Models.UserSkills skill)
		{
			if (skill != null)
			{
				return new API.UserSkills
				{
					UserSkillID = skill.UserSkillID,
					UserID = skill.UserID,
					SkillID = skill.SkillID
				};
			}
			return null;
		}

		public static DAL.Models.EditUserSkill ToAPIEDIT(this API.EditUserSkill skill)
		{
			return new DAL.Models.EditUserSkill
			{
				UserSkillID = skill.UserSkillID,
				UserID = skill.UserID,
				SkillID = skill.SkillID
			};
		}

		public static DAL.Models.EditContract ToAPIEC(this API.EditContract c)
		{
			return new DAL.Models.EditContract
			{
				ContractID = c.ContractID,
				Description = c.Description,
				Price = c.Price,
				DeadLine = c.DeadLine,
				DevId = c.DevId
			};
		}
	}
}
