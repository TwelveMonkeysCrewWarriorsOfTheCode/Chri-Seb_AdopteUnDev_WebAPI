using System.Collections.Generic;

using DAL.Models;

namespace DAL.Interfaces
{
	public interface ISkillRepoLibrary
	{
		public bool InsertSkill(AddSkill s);
		public IEnumerable<Skill> GetSkill();
		public IEnumerable<Skill> GetSkillById(int Id);
		public IEnumerable<SkillCID> GetSkillContractId(int Id);
	}
}
