using System.ComponentModel.DataAnnotations;

namespace Labo2_AdopteUnDev.Models
{
	public class LoginUser
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
