
using System;
using System.Linq;

using DAL.Interfaces;

using Labo2_AdopteUnDev.Models;
using Labo2_AdopteUnDev.Tools;

using Microsoft.AspNetCore.Mvc;

using LoginUser = Labo2_AdopteUnDev.Models.LoginUser;

namespace Labo2_AdopteUnDev.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private IUserRepoLibrary _userService;
		//private ITokenManager _token;

		public UserController(IUserRepoLibrary userService)
		{
			_userService = userService;
		}
		/*public UserController(IUserRepoLibrary userService, ITokenManager token)
        {
            _userService = userService;
            _token = token;
        }*/

		[HttpPost]
		[Route("register")]
		public IActionResult Register([FromBody] UserForm form)
		{
			if (!ModelState.IsValid) return BadRequest();

			_userService.Register(form.Name, form.Email, form.Password, form.Telephone, form.IsClient);
			return Ok();
		}

		[HttpPost]
		[Route("login")]
		public IActionResult Login([FromBody] LoginUser form)
		{
			if (!ModelState.IsValid) return BadRequest();
			Models.User connectedUser = new Models.User();
			//User connectedUser = new User();
			try
			{
				connectedUser = _userService.Login(form.Email, form.Password).ToAPI();
				//_userService.Login(form.Email, form.Password);
			}
			catch (Exception e)
			{
				return BadRequest("Mot de passe invalide !!!");
			}

			//connectedUser = _token.GenerateJWT(connectedUser);

			return Ok(connectedUser);
			//return Ok();
		}

		[HttpGet]
		[Route("GetDev")]
		public IActionResult GetDev()
		{
			return Ok(_userService.GetDev().Select(c => c.ToAPI2()));
			//return Ok(_userService.GetDev().ToAPI2());
		}

		[HttpGet]
		[Route("GetById/{id}")]
		public IActionResult GetById(int id)
		{
			return Ok(_userService.GetById(id).ToAPI2());
		}

		[HttpPost]
		[Route("AddUserSkill")]
		public IActionResult InsertUserSkill(AddUserSkill s)
		{
			if (!ModelState.IsValid) return BadRequest("Ca a foiré");
			_userService.InsertUserSkill(s.ToAPICSk1());
			return Ok("Enregistrement effectué");
		}
		[HttpGet]
		[Route("GetUserSkillUserId/{id}")]
		public IActionResult GetUserSkillUserId(int id)
		{
			return Ok(_userService.GetUserSkillsUserId(id).Select(c => c.ToAPICSk2()));
		}

		[HttpDelete]
		[Route("DeleteUserSkills/{id}")]
		public IActionResult DeleteUserSkills(int id)
		{
			_userService.DeleteUserSkills(id);
			return Ok("Delete effectué");
		}

		[HttpPut]
		[Route("UpdateUserSkill")]
		public IActionResult UpdateUserSkill(Models.EditUserSkill u)
		{
			if (!ModelState.IsValid) return BadRequest("Ca a foiré");
			_userService.UpdateUserSkill(u.ToAPIEDIT());
			return Ok("Modification effectuée");
		}
	}
}
