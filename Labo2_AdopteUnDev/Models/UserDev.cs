namespace Labo2_AdopteUnDev.Models
{
	public class UserDev
	{
		public int UserID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Telephone { get; set; }

		public static explicit operator UserDev(DAL.Models.User user)
		{
			UserDev userDev = new UserDev();
			userDev.UserID = user.UserID;
			userDev.Name = user.Name;
			userDev.Email = user.Email;
			userDev.Telephone = user.Telephone;
			return userDev;
		}
	}
}
