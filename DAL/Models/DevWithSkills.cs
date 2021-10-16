using System.Collections.Generic;

namespace DAL.Models
{
	public class DevWithSkills
	{
		public User Dev { get; set; }
		public IEnumerable<Skill> ListSkills { get; set; }
		public IEnumerable<UserSkills> UserSkills { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}
