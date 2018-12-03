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
    public class TemperatureController : ControllerBase

    {
        private string connectionString = ConnectionString.connectionString;

        // GET: api/Temperature
        [HttpGet]
        public IEnumerable<Temperature> Get()
        {
            string selectString = "SELECT * FROM dbo.RasbiTemp"; 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Temperature> result = new List<Temperature>();
                        while (reader.Read())
                        {
                            Temperature temp = ReadTemp(reader);
                            result.Add(temp);
                        }
                        return result;
                    }
                }
            }
        }

        private Temperature ReadTemp(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            decimal temp = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
            DateTime dateTime = reader.GetDateTime(2);

            Temperature temperature = new Temperature()
            {
                Id = id,
                Temp = temp,
                DT = dateTime
            };

            return temperature;
        }

        // GET: api/Temperature/5
        //[HttpGet("{id}", Name = "Get")]
        [Route("{id}")]
        public Temperature Get(int id)
        {
            string selectString = "SELECT * from dbo.RasbiTemp where id=@id"; 
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
                            return ReadTemp(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }
        }

        // POST: api/Temperature
            [HttpPost]
        public int Post([FromBody] Temperature value)
        {
            string insertString ="INSERT into dbo.RasbiTemp (Temp, DT) values (@temp, @dt)"; 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(insertString, conn))
                {
                    command.Parameters.AddWithValue("@temp", value.Temp);
                    command.Parameters.AddWithValue("@dt", value.DT);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // PUT: api/Temperature/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
