
using System.Collections.Generic;

using DAL.Models;

namespace DAL.Interfaces
{
	public interface IContractRepoLibrary
	{
		public bool InsertContract(AddContract c);
		public IEnumerable<Contract> GetContract();
		public IEnumerable<Contract> GetContractAvailable();
		public IEnumerable<Contract> GetContractAcceptedByDev(int id);
		public IEnumerable<Contract> GetContractIssuedByClient(int id);
		public bool PickContract(PickContract c);
		public bool DeleteContract(int Id);
		public bool UpdateContract(EditContract c);
	}
}
