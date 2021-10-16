using System.Collections.Generic;

using DAL.Models;

namespace DAL.Interfaces
{
	public interface IUserRepoLibrary
	{
		public void Register(string name, string email, string telephone, string password, bool isclient);
		public LoginUser Login(string email, string password);
		public User GetById(int Id);
		public IEnumerable<User> GetDev();
		public bool InsertUserSkill(AddUserSkill s);
		public IEnumerable<UserSkills> GetUserSkillsUserId(int Id);
	}
}
