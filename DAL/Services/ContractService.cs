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
				DevId = reader["DevId"] == DBNull.Value ? null : (int)reader["DevId"]
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
			string query = "SELECT * FROM [Contract]";
			Command cmd = new Command(query);
			return seConnecter().ExecuteReader(cmd, ConvertContractAll);
		}

		public IEnumerable<Contract> GetContractAvailable()
		{
			string query = "SELECT * FROM [Contract] WHERE DevId IS null";
			Command cmd = new Command(query);
			return seConnecter().ExecuteReader(cmd, ConvertContractAll);
		}

		public IEnumerable<Contract> GetContractAcceptedByDev(int id)
		{
			string query = "SELECT * FROM [Contract] WHERE DevId = @UserID";
			Command cmd = new Command(query);
			cmd.AddParameter("UserId", id);
			return seConnecter().ExecuteReader(cmd, ConvertContractAll);
		}

		public IEnumerable<Contract> GetContractIssuedByClient(int id)
		{
			string query = "SELECT * FROM [Contract] WHERE ClientId = @UserID";
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
	}
}
