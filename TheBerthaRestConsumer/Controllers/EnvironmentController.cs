﻿using System;
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
        }

        private Model.Environment ReadEnvironment(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            decimal oxygen = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1); ;
            decimal co2 = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
            decimal co = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
            decimal pm25 = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
            decimal pm10 = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);
            decimal ozon = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);
            decimal dustParticles = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7);
            decimal nitrogenDioxide = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8);
            decimal sulphurDioxide = reader.IsDBNull(9) ? 0 : reader.GetDecimal(9);
            int userId = reader.GetInt32(10);
            DateTime dateTimeInfo = reader.GetDateTime(11);

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
                DateTimeInfo = dateTimeInfo
        };
            return env;
        }

        // GET: api/Environment/5
        [HttpGet("{id}", Name = "Get")]
        public Model.Environment Get(int id)
        {
            string selectString = "select * from EnvironmentData where id = @id"; //
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
        }

        // POST: api/Environment
        [HttpPost]
        public int Post([FromBody] Model.Environment value)
        {
            string insertString = "insert into EnvironmentData (oxygen, co2, co, [PM2.5], PM10, ozon, dustParticles, nitrogenDioxide, sulphurDioxide, userId, dateTimeInfo) values(@oxygen, @co2, @co, @PM25, @PM10, @ozon, @dustParticles, @nitrogenDioxide, @sulphurDioxide, @userId, @dateTimeInfo)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(insertString, conn))
                {
                    command.Parameters.AddWithValue("@oxygen", value.Oxygen);
                    command.Parameters.AddWithValue("@co2", value.Co2);
                    command.Parameters.AddWithValue("@co", value.Co);
                    command.Parameters.AddWithValue("@PM25", value.Pm25);
                    command.Parameters.AddWithValue("@PM10", value.Pm10);
                    command.Parameters.AddWithValue("@ozon", value.Ozon);
                    command.Parameters.AddWithValue("@dustParticles", value.DustParticles);
                    command.Parameters.AddWithValue("@nitrogenDioxide", value.NitrogenDioxide);
                    command.Parameters.AddWithValue("@sulphurDioxide", value.SulphurDioxide);
                    command.Parameters.AddWithValue("@userId", value.UserId);
                    command.Parameters.AddWithValue("@dateTimeInfo", value.DateTimeInfo);

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
                "update EnvironmentData set oxygen =@oxygen, co2=@co2, co =@co, [PM2.5] =@pm25, PM10 =@pm10, ozon =@ozon, dustParticles =@dustParticles, nitrogenDioxide =@nitrogenDioxide, sulphurDioxide =@sulphurDioxide, userId =@userId, dateTimeInfo =@dateTimeInfo where id=@id"; 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand updateCommand = new SqlCommand(updateString, conn))
                {
                    //updateCommand.Parameters.AddWithValue("@Id", value.Id);
                    updateCommand.Parameters.AddWithValue("@id", id);
                    updateCommand.Parameters.AddWithValue("@oxygen", value.Oxygen);
                    updateCommand.Parameters.AddWithValue("@co2", value.Co2);
                    updateCommand.Parameters.AddWithValue("@co", value.Co);
                    updateCommand.Parameters.AddWithValue("@pm25", value.Pm25);
                    updateCommand.Parameters.AddWithValue("@pm10", value.Pm10);
                    updateCommand.Parameters.AddWithValue("@ozon", value.Ozon);
                    updateCommand.Parameters.AddWithValue("@dustParticles", value.DustParticles);
                    updateCommand.Parameters.AddWithValue("@nitrogenDioxide", value.NitrogenDioxide);
                    updateCommand.Parameters.AddWithValue("@sulphurDioxide", value.SulphurDioxide);
                    updateCommand.Parameters.AddWithValue("@userId", value.UserId);
                    updateCommand.Parameters.AddWithValue("@dateTimeInfo", value.DateTimeInfo);

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