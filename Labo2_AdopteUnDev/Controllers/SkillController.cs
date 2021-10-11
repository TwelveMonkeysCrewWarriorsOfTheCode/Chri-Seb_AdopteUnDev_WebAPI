using System.Linq;

using DAL.Interfaces;

using Labo2_AdopteUnDev.Models;

using Labo2_AdopteUnDev.Tools;

using Microsoft.AspNetCore.Mvc;

namespace Labo2_AdopteUnDev.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SkillController : ControllerBase
	{
		private ISkillRepoLibrary _skillService;

		public SkillController(ISkillRepoLibrary skillService)
		{
			_skillService = skillService;
		}

		[HttpPost]
		[Route("AddSkill")]
		public IActionResult InsertSkill(AddSkill s)
		{
			if (!ModelState.IsValid) return BadRequest("Ca a foiré");
			_skillService.InsertSkill(s.ToAPICS2());
			return Ok("Enregistrement effectué");
		}
		[HttpGet]
		[Route("GetSkill")]
		public IActionResult GetSkill()
		{
			return Ok(_skillService.GetSkill().Select(c => c.ToAPICCS()));
			//return Ok(_userService.GetDev().ToAPI2());
		}
		[HttpGet]
		[Route("GetSkillById/{id}")]
		public IActionResult GetSkillById(int id)
		{
			return Ok(_skillService.GetSkillById(id).Select(c => c.ToAPICCS()));
			//return Ok(_userService.GetDev().ToAPI2());
		}
		[HttpGet]
		[Route("GetSkillContractId/{id}")]
		public IActionResult GetSkillContractId(int id)
		{
			return Ok(_skillService.GetSkillContractId(id).Select(c => c.ToAPICS()));
			//return Ok(_userService.GetDev().ToAPI2());
		}
	}
}
