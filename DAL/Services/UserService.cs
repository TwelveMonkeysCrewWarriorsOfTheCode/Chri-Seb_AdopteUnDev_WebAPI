using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using ADOLibrary;

using DAL.Interfaces;
using DAL.Models;

using Microsoft.Extensions.Configuration;

namespace DAL.Services
{
	public class UserService : IUserRepoLibrary
	{
		private string _connectionString;

		public UserService(IConfiguration config)
		{
			_connectionString = config.GetConnectionString("Default");
		}

		private Connection seConnecter()
		{
			return new Connection(_connectionString);
		}

		private LoginUser ConvertUser(SqlDataReader reader)
		{
			return new LoginUser
			{
				UserID = reader["UserId"] == DBNull.Value ? null : (int)reader["UserId"],
				Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
				//Password = reader["Password"].ToString(),
				IsClient = reader["IsClient"] == DBNull.Value ? null : (bool)reader["IsClient"]
			};
		}

		public void Register(string name, string email, string password, string telephone, bool isclient)
		{
			Command cmd = new Command("UserRegister", true);
			cmd.AddParameter("Name", name);
			cmd.AddParameter("Email", email);
			cmd.AddParameter("Password", password);
			cmd.AddParameter("Telephone", telephone);
			cmd.AddParameter("IsClient", isclient);

			seConnecter().ExecuteNonQuery(cmd);
		}

		public LoginUser Login(string email, string password)
		{
			Command cmd = new Command("UserLogin", true);
			cmd.AddParameter("Email", email);
			cmd.AddParameter("Password", password);

			try
			{
				return seConnecter().ExecuteReader(cmd, ConvertUser).FirstOrDefault();
				/*LoginUser ulog = seConnecter().ExecuteReader(cmd, ConvertUser).FirstOrDefault();
                if (ulog != null)
                {
                    return ulog;
                }
                else
                {
                    throw new Exception();
                }*/
			}
			catch (SqlException e)
			{
				throw new Exception(e.Message);
			}
		}
		private User ConvertUserAll(SqlDataReader reader)
		{
			return new User
			{
				UserID = (int)reader["UserId"],
				Name = reader["Name"].ToString(),
				Email = reader["Email"].ToString(),
				Telephone = reader["Telephone"].ToString()
			};
		}
		public User GetById(int Id)
		{
			string query = "SELECT * FROM [User] WHERE UserId = @UserId";
			Command cmd = new Command(query);
			cmd.AddParameter("UserId", Id);
			return seConnecter().ExecuteReader(cmd, ConvertUserAll).FirstOrDefault();
		}
		public IEnumerable<User> GetDev()
		{
			string query = "SELECT * FROM [User] WHERE IsClient = @IsClient";
			Command cmd = new Command(query);
			cmd.AddParameter("IsClient", 0);
			return seConnecter().ExecuteReader(cmd, ConvertUserAll);
		}
		public bool InsertUserSkill(AddUserSkill s)
		{
			string query = "INSERT INTO UserSkill (UserID, SkillID VALUES(@us, @sk)";
			Command cmd = new Command(query);
			cmd.AddParameter("us", s.UserID);
			cmd.AddParameter("sk", s.SkillID);
			return seConnecter().ExecuteNonQuery(cmd) == 1;
		}
		private UserSkills ConvertUserSkill(SqlDataReader reader)
		{
			return new UserSkills
			{
				UserSkillID = reader["UserSkillID"] == DBNull.Value ? null : (int)reader["UserSkillID"],
				UserID = reader["UserID"] == DBNull.Value ? null : (int)reader["UserID"],
				SkillID = reader["SkillID"] == DBNull.Value ? null : (int)reader["SkillID"]
			};
		}
		public IEnumerable<UserSkills> GetUserSkillsUserId(int Id)
		{
			string query = "SELECT * FROM [UserSkills] WHERE UserID = @UserID";
			Command cmd = new Command(query);
			cmd.AddParameter("UserID", Id);
			return seConnecter().ExecuteReader(cmd, ConvertUserSkill);
		}
	}
}
