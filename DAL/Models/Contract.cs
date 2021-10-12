namespace DAL.Models
{
	public class Contract
	{
		public int? ContractID { get; set; }
		public string Description { get; set; }
		public int? Price { get; set; }
		public string DeadLine { get; set; }
		public int? ClientId { get; set; }
		public int? DevId { get; set; }
		public string UName { get; set; }
	}
}
