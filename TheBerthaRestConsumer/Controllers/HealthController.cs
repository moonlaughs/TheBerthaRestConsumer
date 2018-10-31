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
    public class HealthController : ControllerBase
    {
        private string connectionString = ConnectionString.connectionString;

        // GET: api/Health
        [HttpGet]
        public IEnumerable<Health> Get()
        {
            string selectString = "select * from HealthData;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Health> result = new List<Health>();
                        while (reader.Read())
                        {
                            Health health = ReadHealth(reader);
                            result.Add(health);
                        }   
                        return result;
                    }
                }
            }
        }

        internal static Health ReadHealth(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            int bloodPressureUpper = reader.GetInt32(1);
            int bloodPressureDown = reader.GetInt32(2);
            int heartRate = reader.GetInt32(3);
            decimal temperature = reader.GetDecimal(4);
            int userId = reader.GetInt32(5);
            DateTime dateTimeInfo = reader.GetDateTime(6);
            Health health = new Health()
            {
                Id = id,
                BloodPressureUpper = bloodPressureUpper,
                BloodPressureDown = bloodPressureDown,
                HeartRate = heartRate,
                Temperature = temperature,
                UserId = userId,
                DateTimeInfo = dateTimeInfo
            };

            return health;
        }

        // GET: api/Health/5
        //[HttpGet("{id}", Name = "Get")]
        [Route("{id}")]
        public Health Get(int id)
        {
            string selectString = "select * from HealthData where id = @id";
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
                            return ReadHealth(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        // POST: api/Health
        [HttpPost]
        public int Post([FromBody] Health value)
        {
            string insertString = "insert into HealthData (bloodPressureUpper, bloodPressureDown, heartRate, temperature, userId, dateTimeInfo) values(@bloodPressureUpper, @bloodPressureDown, @heartRate, @temperature, @userId, @dateTimeInfo); ";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(insertString, conn))
                {
                    command.Parameters.AddWithValue("@bloodPressureUpper", value.BloodPressureUpper);
                    command.Parameters.AddWithValue("@bloodPressureDown", value.BloodPressureDown);
                    command.Parameters.AddWithValue("@heartRate", value.HeartRate);
                    command.Parameters.AddWithValue("@temperature", value.Temperature);
                    command.Parameters.AddWithValue("@userId", value.UserId);
                    command.Parameters.AddWithValue("@dateTimeInfo", value.DateTimeInfo);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // PUT: api/Health/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Health value)
        {
            const string updateString = "update HealthData set bloodPressureUpper=@bloodPressureUpper, bloodPressureDown=@bloodPressureDown," +
                " heartRate=@heartRate, temperature=@temperature, userId=@userId, dateTimeInfo=@dateTimeInfo where id=@id;";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand updateCommand = new SqlCommand(updateString, databaseConnection))
                {
                    updateCommand.Parameters.AddWithValue("@bloodPressureUpper", value.BloodPressureUpper);
                    updateCommand.Parameters.AddWithValue("@bloodPressureDown", value.BloodPressureDown);
                    updateCommand.Parameters.AddWithValue("@heartRate", value.HeartRate);
                    updateCommand.Parameters.AddWithValue("@temperature", value.Temperature);
                    updateCommand.Parameters.AddWithValue("@userId", value.UserId);
                    updateCommand.Parameters.AddWithValue("@dateTimeInfo", value.DateTimeInfo);
                    updateCommand.Parameters.AddWithValue("@id", id);
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    return rowsAffected;
                }

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            string deleteString = "delete from HealthData where id = @id";
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
