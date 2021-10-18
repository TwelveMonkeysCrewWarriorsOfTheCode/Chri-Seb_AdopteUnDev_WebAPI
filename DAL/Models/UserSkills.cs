namespace DAL.Models
{
	public class UserSkills
	{
		public int? UserSkillID { get; set; }
		public int? UserID { get; set; }
		public int? SkillID { get; set; }
		public string SkillName { get; set; }
		public string CName { get; set; }
	}
}
