
using System.Linq;

using DAL.Interfaces;

using Labo2_AdopteUnDev.Models;
using Labo2_AdopteUnDev.Tools;

using Microsoft.AspNetCore.Mvc;

namespace Labo2_AdopteUnDev.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContractController : ControllerBase
	{
		private IContractRepoLibrary _contractService;
		public ContractController(IContractRepoLibrary contractService)
		{
			_contractService = contractService;
		}

		[HttpPost]
		[Route("AddContract")]
		public IActionResult InsertContract(AddContract c)
		{
			if (!ModelState.IsValid) return BadRequest();
			_contractService.InsertContract(c.ToAPIc2());

			return Ok("Contrat enregistré");
		}

		[HttpGet]
		[Route("GetContract")]
		public IActionResult GetContract()
		{
			return Ok(_contractService.GetContract().Select(c => c.ToAPIc()));
		}

		[HttpGet]
		[Route("GetContractAvailable")]
		public IActionResult GetContractAvailale()
		{
			return Ok(_contractService.GetContractAvailable().Select(c => c.ToAPIc()));
		}

		[HttpGet]
		[Route("GetContractAcceptedByDev/{id}")]
		public IActionResult GetContractAcceptedByDev(int id)
		{
			return Ok(_contractService.GetContractAcceptedByDev(id).Select(c => c.ToAPIc()));
		}

		[HttpGet]
		[Route("GetContractIssuedByClient/{id}")]
		public IActionResult GetContractIssuedByClient(int id)
		{
			return Ok(_contractService.GetContractIssuedByClient(id).Select(c => c.ToAPIc()));
		}

		[HttpPut]
		[Route("PickContract")]
		public IActionResult PickContract(PickContract c)
		{
			if (!ModelState.IsValid) return BadRequest();
			_contractService.PickContract(c.ToAPICPC());

			return Ok("Contrat accepté");
		}
	}
}
