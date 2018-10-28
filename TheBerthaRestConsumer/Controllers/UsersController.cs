using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBerthaRestConsumer.Model;

namespace TheBerthaRestConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private string connectionString = ConnectionString.connectionString;
        
        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            string selectString = "SELECT * FROM users;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Users> result = new List<Users>();
                        while (reader.Read())
                        {
                            Users user = ReadUser(reader);
                            result.Add(user);
                        }
                        return result;
                    }
                }
            }
            return null;
        }

        private Users ReadUser(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string firstName = reader.GetString(1);
            string lastName = reader.GetString(2);
            string userName = reader.GetString(3);
            string pass = reader.GetString(4);
            int age = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            string gender = reader.GetString(6);
            string typeOfUser = reader.GetString(7);

            Users user = new Users()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Pass = pass,
                Age = age,
                Gender = gender,
                TypeOfUser = typeOfUser
            };

            return user;
        }

        // GET: api/Users/5
        [Route("{id}")]
        public Users Get(int id)
        {
            string selectSring = "SELECT * from Users WHERE id = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectSring, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return ReadUser(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }

            return null;
        }

        //Get the health data of a specific user
        [Route("{userId}/health")]
        public IEnumerable<Health> GetScoresByUserId(int userId)
        {
            const string selectString = "select * from HealthData where userid=@userid";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    selectCommand.Parameters.AddWithValue("@userid", userId);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<Health> healthList = new List<Health>();
                        while (reader.Read())
                        {
                            Health health = HealthController.ReadHealth(reader);
                            healthList.Add(health);
                        }
                        return healthList;
                    }
                }
            }
        }

        // POST: api/Users
        [HttpPost]
        public int Post([FromBody] Users value)
        {
            string inseartString = "INSERT INTO dbo.Users (FirstName, LastName, UserName, Pass, Age, Gender, TypeOfUser) values(@firstName, @lastName, @userName, @pass, @age, @gender, @typeOfUser); ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(inseartString, conn))
                {
                    command.Parameters.AddWithValue("@firstName", value.FirstName);
                    command.Parameters.AddWithValue("@lastName", value.LastName);
                    command.Parameters.AddWithValue("@userName", value.UserName);
                    command.Parameters.AddWithValue("@pass", value.Pass);
                    command.Parameters.AddWithValue("@age", value.Age);
                    command.Parameters.AddWithValue("@gender", value.Gender);
                    command.Parameters.AddWithValue("@typeOfUser", value.TypeOfUser);
                    int rowAffected = command.ExecuteNonQuery();
                    return rowAffected;
                }
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Users value)
        {
            string updateString = "update Users set FirstName = @firstName, LastName = @lastName, UserNAme = @userName, Pass = @pass, Age = @age, Gender = @gender, TypeOfUser = @TypeOfUser where id = @id; ";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(updateString, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@firstName", value.FirstName);
                    command.Parameters.AddWithValue("@lastName", value.LastName);
                    command.Parameters.AddWithValue("@userName", value.UserName);
                    command.Parameters.AddWithValue("@pass", value.Pass);
                    command.Parameters.AddWithValue("@age", value.Age);
                    command.Parameters.AddWithValue("@gender", value.Gender);
                    command.Parameters.AddWithValue("@typeOfUser", value.TypeOfUser);
                    int rowAffected = command.ExecuteNonQuery();
                    return rowAffected;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            string deleteString = "DELETE FROM USERS WHERE ID = @id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(deleteString, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rowAffected = command.ExecuteNonQuery();
                    return rowAffected;
                }
            }
        }
    }
}
