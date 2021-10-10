namespace DAL.Models
{
	public class LoginUser
	{
		public int? UserID { get; set; }
		public string Email { get; set; }
		public bool? IsClient { get; set; }
	}
}
