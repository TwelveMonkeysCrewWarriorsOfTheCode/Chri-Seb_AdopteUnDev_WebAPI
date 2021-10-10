
using API = Labo2_AdopteUnDev.Models;

namespace Labo2_AdopteUnDev.Tools
{
	public static class Mappers
	{
		public static API.User ToAPI(this DAL.Models.LoginUser user)
		{
			if (user != null)
			{
				return new API.User
				{
					UserID = user.UserID,
					Email = user.Email,
					//Password = user.Password
					IsClient = user.IsClient
				};
			}
			return null;
		}

		public static API.UserDev ToAPI2(this DAL.Models.User user)
		{
			return new API.UserDev
			{
				UserID = user.UserID,
				Name = user.Name,
				Email = user.Email,
				Telephone = user.Telephone
			};
		}
		public static API.Contract ToAPIc(this DAL.Models.Contract contract)
		{
			if (contract != null)
			{
				return new API.Contract
				{
					ContractID = contract.ContractID,
					Description = contract.Description,
					Price = contract.Price,
					DeadLine = contract.DeadLine,
					ClientId = contract.ClientId,
					DevId = contract.DevId
				};
			}
			return null;
		}
		public static DAL.Models.AddContract ToAPIc2(this API.AddContract contract)
		{
			return new DAL.Models.AddContract
			{
				Description = contract.Description,
				Price = contract.Price,
				DeadLine = contract.DeadLine,
				ClientId = contract.ClientId
			};
		}
		public static DAL.Models.PickContract ToAPICPC(this API.PickContract contract)
		{
			return new DAL.Models.PickContract
			{
				ContractID = contract.ContractID,
				DevId = contract.DevId
			};
		}
	}
}
