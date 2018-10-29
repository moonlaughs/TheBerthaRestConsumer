using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Dependency;

namespace TheBerthaRestConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private string connectionString = ConnectionString.connectionString;
        // GET: api/Environment
        [HttpGet]
        public IEnumerable<Model.Environment> Get()
        {
            string selectString = "select * from EnvironmentData";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); 
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        List<Model.Environment> result = new List<Model.Environment>();
                        while (reader.Read()) 
                        {
                            Model.Environment env = ReadEnvironment(reader);
                            result.Add(env);
                        }
                        return result;
                    }
                }
            }

            return null;
        }

        private Model.Environment ReadEnvironment(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string oxygen = reader.IsDBNull(1) ? null : reader.GetString(1); ;
            string co2 = reader.IsDBNull(2) ? null : reader.GetString(2);
            string co = reader.IsDBNull(3) ? null : reader.GetString(3);
            string pm25 = reader.IsDBNull(4) ? null : reader.GetString(4);
            string pm10 = reader.IsDBNull(5) ? null : reader.GetString(5);
            string ozon = reader.IsDBNull(6) ? null : reader.GetString(6);
            string dustParticles = reader.IsDBNull(7) ? null : reader.GetString(7);
            string nitrogenDioxide = reader.IsDBNull(8) ? null : reader.GetString(8);
            string sulphurDioxide = reader.IsDBNull(9) ? null : reader.GetString(9);
            int userId = reader.GetInt32(10);
            DateTime dateTime = reader.GetDateTime(11);

            Model.Environment env = new Model.Environment()
            {
                Id = id,
                Oxygen = oxygen,
                Co2 = co2,
                Co = co,
                Pm25 = pm25,
                Pm10 = pm10,
                Ozon = ozon,
                DustParticles = dustParticles,
                NitrogenDioxide = nitrogenDioxide,
                SulphurDioxide = sulphurDioxide,
                UserId = userId,
                DateTime = dateTime
        };
            return env;
        }

        // GET: api/Environment/5
        [HttpGet("{id}", Name = "Get")]
        public Model.Environment Get(int id)
        {
            string selectString = "select * from Environment where id = @id"; //
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        if (reader.HasRows)
                        {
                            reader.Read(); 
                            return ReadEnvironment(reader); 
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

        // POST: api/Environment
        [HttpPost]
        public int Post([FromBody] Model.Environment value)
        {
            string insertString = "insert into books (title, author, publisher, price) values(@title, @author, @publisher, @price)"; // change with the things from database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(insertString, conn))
                {
                    command.Parameters.AddWithValue("@id", value.Id);
                    command.Parameters.AddWithValue("@oxygen", value.Oxygen);
                    command.Parameters.AddWithValue("@co2", value.Co2);
                    command.Parameters.AddWithValue("@pm25", value.Pm25);
                    command.Parameters.AddWithValue("@pm10", value.Pm10);
                    command.Parameters.AddWithValue("@ozone", value.Ozon);
                    command.Parameters.AddWithValue("@dustParticles", value.DustParticles);
                    command.Parameters.AddWithValue("@nitrogenDioxide", value.NitrogenDioxide);
                    command.Parameters.AddWithValue("@sulphirDioxide", value.SulphurDioxide);
                    command.Parameters.AddWithValue("@userId", value.UserId);
                    command.Parameters.AddWithValue("@dateTime", value.DateTime);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // PUT: api/Environment/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Model.Environment value)
        {
            string updateString =
                "update books set title =@title, author= @author, publisher= @publisher, price= @price where id=@id"; // here as well
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand updateCommand = new SqlCommand(updateString, conn))
                {
                    updateCommand.Parameters.AddWithValue("@id", value.Id);
                    updateCommand.Parameters.AddWithValue("@oxygen", value.Oxygen);
                    updateCommand.Parameters.AddWithValue("@co2", value.Co2);
                    updateCommand.Parameters.AddWithValue("@pm25", value.Pm25);
                    updateCommand.Parameters.AddWithValue("@pm10", value.Pm10);
                    updateCommand.Parameters.AddWithValue("@ozone", value.Ozon);
                    updateCommand.Parameters.AddWithValue("@dustParticles", value.DustParticles);
                    updateCommand.Parameters.AddWithValue("@nitrogenDioxide", value.NitrogenDioxide);
                    updateCommand.Parameters.AddWithValue("@sulphirDioxide", value.SulphurDioxide);
                    updateCommand.Parameters.AddWithValue("@userId", value.UserId);
                    updateCommand.Parameters.AddWithValue("@dateTime", value.DateTime);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            string deleteString = "delete from books where id = @id"; // here change with query
            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(deleteString, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();   
                    return rowsAffected;
                }
            }
        }
    }
}
