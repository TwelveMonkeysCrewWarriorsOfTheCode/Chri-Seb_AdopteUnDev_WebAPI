using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using ADOLibrary;

using DAL.Interfaces;
using DAL.Models;

using Microsoft.Extensions.Configuration;

namespace DAL.Services
{
	public class ContractService : IContractRepoLibrary
	{
		private string _connectionString;

		public ContractService(IConfiguration config)
		{
			_connectionString = config.GetConnectionString("Default");
		}

		private Connection seConnecter()
		{
			return new Connection(_connectionString);
		}

		private Contract ConvertContractAll(SqlDataReader reader)
		{
			return new Contract
			{
				ContractID = reader["ContractID"] == DBNull.Value ? null : (int)reader["ContractID"],
				Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString(),
				Price = reader["Price"] == DBNull.Value ? null : (int)reader["Price"],
				DeadLine = reader["DeadLine"] == DBNull.Value ? null : reader["DeadLine"].ToString(),
				ClientId = reader["ClientId"] == DBNull.Value ? null : (int)reader["ClientId"],
				DevId = reader["DevId"] == DBNull.Value ? null : (int)reader["DevId"],
				UName = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString()
			};

		}

		public bool InsertContract(AddContract c)
		{
			string query = "INSERT INTO Contract (Description, Price, DeadLine, ClientId)" +
				" VALUES(@de, @pr, @dea, @cli)";
			Command cmd = new Command(query);
			cmd.AddParameter("de", c.Description);
			cmd.AddParameter("pr", c.Price);
			cmd.AddParameter("dea", c.DeadLine);
			cmd.AddParameter("cli", c.ClientId);

			return seConnecter().ExecuteNonQuery(cmd) == 1;
		}

		public IEnumerable<Contract> GetContract()
		{
			string query = "SELECT ContractID, Description, Price, DeadLine, ClientID, DevID, Name FROM [Contract] INNER JOIN [User] ON Contract.ClientID = [User].UserID";
			Command cmd = new Command(query);
			return seConnecter().ExecuteReader(cmd, ConvertContractAll);
		}

		public IEnumerable<Contract> GetContractAvailable()
		{
			string query = "SELECT ContractID, Description, Price, DeadLine, ClientID, DevID, Name FROM [Contract] INNER JOIN [User] ON Contract.ClientID = [User].UserID WHERE DevID is null";
			Command cmd = new Command(query);
			return seConnecter().ExecuteReader(cmd, ConvertContractAll);
		}

		public IEnumerable<Contract> GetContractAcceptedByDev(int id)
		{
			string query = "SELECT ContractID, Description, Price, DeadLine, ClientID, DevID, Name FROM [Contract] INNER JOIN [User] ON Contract.ClientID = [User].UserID WHERE DevId = @UserID";
			Command cmd = new Command(query);
			cmd.AddParameter("UserId", id);
			return seConnecter().ExecuteReader(cmd, ConvertContractAll);
		}

		public IEnumerable<Contract> GetContractIssuedByClient(int id)
		{
			string query = "SELECT ContractID, Description, Price, DeadLine, ClientID, DevID, Name FROM [Contract] LEFT JOIN [User] ON Contract.DevID = [User].UserID WHERE ClientId = @UserID";
			Command cmd = new Command(query);
			cmd.AddParameter("UserId", id);
			return seConnecter().ExecuteReader(cmd, ConvertContractAll);
		}

		public bool PickContract(PickContract c)
		{
			string query = "UPDATE [Contract] SET [DevId] = @did WHERE ContractID = @ContractID";
			Command cmd = new Command(query);
			cmd.AddParameter("did", c.DevId);
			cmd.AddParameter("ContractID", c.ContractID);

			return seConnecter().ExecuteNonQuery(cmd) == 1;
		}

		public bool DeleteContract(int Id)
		{
			string query = "DELETE FROM [Contract] WHERE ContractID = @ContractID";
			Command cmd = new Command(query);
			cmd.AddParameter("ContractId", Id);

			return seConnecter().ExecuteNonQuery(cmd) == 1;
		}
		public bool UpdateContract(EditContract c)
		{
			string query = "UPDATE [Contract] SET Description = @de, Price = @pr, DeadLine = @dl, DevId = @di WHERE ContractID = @ContractID";
			Command cmd = new Command(query);
			cmd.AddParameter("ContractID", c.ContractID);
			cmd.AddParameter("de", c.Description);
			cmd.AddParameter("pr", c.Price);
			cmd.AddParameter("dl", c.DeadLine);
			cmd.AddParameter("di", c.DevId);

			return seConnecter().ExecuteNonQuery(cmd) == 1;
		}
	}
}