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
        }

        private Users ReadUser(SqlDataReader reader)
        {
            int myid = reader.GetInt32(0);
            string myfirstName = reader.GetString(1);
            string mylastName = reader.GetString(2);
            string myuserName = reader.GetString(3);
            string mypass = reader.GetString(4);
            int myyear = reader.IsDBNull(5) ? 0: reader.GetInt32(5);
            string mygender = reader.GetString(6);
            string mytypeOfUser = reader.GetString(7);

            Users user = new Users()
            {
                id = myid,
                firstName = myfirstName,
                lastName = mylastName,
                userName = myuserName,
                pass = mypass,
                year = myyear,
                gender = mygender,
                typeOfUser = mytypeOfUser
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

        // Get environment data of a specific user
        [Route("{userId}/environment")]

        public IEnumerable<EnvironmentClass> GetEnvByUserId(int userId)
        {
            const string selectString = "select * from EnvironmentData where userid =@userid";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    selectCommand.Parameters.AddWithValue("@userid", userId);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<EnvironmentClass> envList = new List<EnvironmentClass>();
                        while (reader.Read())
                        {
                            EnvironmentClass env = EnvironmentController.ReadEnvironment(reader);
                            envList.Add(env);
                        }
                        return envList;
                    }
                }
            }
        }      
                
        // POST: api/Users
        [HttpPost]
        public bool Post([FromBody] Users value)
        {
            string inseartString = "INSERT INTO dbo.Users (FirstName, LastName, UserName, Pass, Year, Gender, TypeOfUser) values(@firstName, @lastName, @userName, @pass, @year, @gender, @typeOfUser); ";

            bool item = CheckUsernameValidation(value.userName);

            if (item == true)
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(inseartString, conn))
                    {
                        command.Parameters.AddWithValue("@firstName", value.firstName);
                        command.Parameters.AddWithValue("@lastName", value.lastName);
                        command.Parameters.AddWithValue("@userName", value.userName);
                        command.Parameters.AddWithValue("@pass", value.pass);
                        command.Parameters.AddWithValue("@year", value.year);
                        command.Parameters.AddWithValue("@gender", value.gender);
                        command.Parameters.AddWithValue("@typeOfUser", value.typeOfUser);

                        int rowsAffected = command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            else
                return false;
        }

        //[Route("{usernameValidation}")]
        public bool CheckUsernameValidation(string usernameValidation)
        {
            string usernameValidationString = "SELECT * from Users WHERE userName = @userNameValid;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(usernameValidationString, conn))
                {
                    command.Parameters.AddWithValue("@userNameValid", usernameValidation);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Users value)
        {
            string updateString = "update Users set FirstName = @firstName, LastName = @lastName, UserName = @userName, Pass = @pass, Year = @year, Gender = @gender, TypeOfUser = @TypeOfUser where id = @id; ";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(updateString, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@firstName", value.firstName);
                    command.Parameters.AddWithValue("@lastName", value.lastName);
                    command.Parameters.AddWithValue("@userName", value.userName);
                    command.Parameters.AddWithValue("@pass", value.pass);
                    command.Parameters.AddWithValue("@year", value.year);
                    command.Parameters.AddWithValue("@gender", value.gender);
                    command.Parameters.AddWithValue("@typeOfUser", value.typeOfUser);
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

        [Route("login/{username}/{pass}")]
        public Users Login(string username, string pass)
        {
            var collection = Get();
            if (collection != null)
            {
                foreach(var user in collection)
                {
                    if ((user.userName == username) && (user.pass == pass))
                    {
                        return user;

                    }
                }
            }
            return null;
        }

    }
}
