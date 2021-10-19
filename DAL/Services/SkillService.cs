using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using ADOLibrary;

using DAL.Interfaces;
using DAL.Models;

using Microsoft.Extensions.Configuration;

namespace DAL.Services
{
	public class SkillService : ISkillRepoLibrary
	{
		private string _connectionString;

		public SkillService(IConfiguration config)
		{
			_connectionString = config.GetConnectionString("Default");
		}

		private Connection seConnecter()
		{
			return new Connection(_connectionString);
		}
		public bool InsertSkill(AddSkill s)
		{
			string query = "INSERT INTO NeededSkills (ContractID, SkillID)" +
				" VALUES(@co, @sk)";
			Command cmd = new Command(query);
			cmd.AddParameter("co", s.ContractID);
			cmd.AddParameter("sk", s.SkillID);

			return seConnecter().ExecuteNonQuery(cmd) == 1;
		}
		private Skill ConvertSkill(SqlDataReader reader)
		{
			return new Skill
			{
				SkillID = reader["SkillID"] == DBNull.Value ? null : (int)reader["SkillID"],
				Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString(),
				Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString(),
				CName = reader["CName"] == DBNull.Value ? null : reader["CName"].ToString()
			};
		}
		private SkillCID ConvertSkill2(SqlDataReader reader)
		{
			return new SkillCID
			{
				NeededSkillsID = reader["NeededSkillID"] == DBNull.Value ? null : (int)reader["NeededSkillID"],
				ContractID = reader["ContractID"] == DBNull.Value ? null : (int)reader["ContractID"],
				SkillID = reader["SkillID"] == DBNull.Value ? null : (int)reader["SkillID"]
			};
		}
		public IEnumerable<Skill> GetSkill()
		{
			string query = "select SkillID, [Skill].Name, Description, [Category].Name as CName from [Skill] INNER JOIN Category ON Skill.CategoryID = Category.CategoryID ORDER BY CName";
			Command cmd = new Command(query);
			return seConnecter().ExecuteReader(cmd, ConvertSkill);
		}
		public IEnumerable<Skill> GetSkillById(int Id)
		{
			string query = "select SkillID, [Skill].Name, Description, [Category].Name as CName from [Skill] INNER JOIN Category ON Skill.CategoryID = Category.CategoryID WHERE SkillId = @SkillId";
			Command cmd = new Command(query);
			cmd.AddParameter("SkillId", Id);
			return seConnecter().ExecuteReader(cmd, ConvertSkill);
		}
		public IEnumerable<SkillCID> GetSkillContractId(int Id)
		{
			string query = "SELECT * FROM [NeededSkill] WHERE ContractID = @ContractID";
			Command cmd = new Command(query);
			cmd.AddParameter("ContractID", Id);
			return seConnecter().ExecuteReader(cmd, ConvertSkill2);
		}
	}
}
