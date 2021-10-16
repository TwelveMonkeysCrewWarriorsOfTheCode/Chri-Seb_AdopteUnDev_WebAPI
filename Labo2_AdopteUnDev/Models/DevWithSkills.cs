using System.Collections.Generic;

namespace Labo2_AdopteUnDev.Models
{
	public class DevWithSkills
	{
		public UserDev Dev { get; set; }
		public IEnumerable<Skill> ListSkills { get; set; }
		public IEnumerable<UserSkills> UserSkills { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}
