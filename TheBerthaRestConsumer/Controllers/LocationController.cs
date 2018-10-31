using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using TheBerthaRestConsumer.Model;


namespace TheBerthaRestConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private string connectionString = ConnectionString.connectionString;

        // GET: api/Location
        [HttpGet]
        public IEnumerable<Model.Location> GetLocation()
        {
            const string selectString = "select * from LocationData order by id";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<Model.Location> locationList = new List<Model.Location>();
                        while (reader.Read())
                        {
                            Model.Location location = ReadLocation(reader);
                            locationList.Add(location);
                        }
                        return locationList;
                    }
                }
            }
        }

        internal static Model.Location ReadLocation(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            decimal longitude = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
            decimal latitude = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
            int userId = reader.GetInt32(3);
            DateTime dateTimeInfo = reader.GetDateTime(4);
            Model.Location location = new Model.Location
            {
                Id = id,
                Longitude = longitude,
                Latitude = latitude,
                UserId = userId,
                DateTimeInfo = dateTimeInfo
            };
            return location;
        }

        // GET: api/Books/5
        [Route("{id}")]
        public Model.Location GetLocationById(int id)
        {
            const string selectString = "select * from LocationData where id=@id";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    selectCommand.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.HasRows) { return null; }
                        reader.Read(); // advance cursor to first row
                        return ReadLocation(reader);
                    }
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int DeleteLocation(int id)
        {
            const string deleteStatement = "delete from LocationData where id=@id";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(deleteStatement, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@id", id);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // POST: api/Location
        [HttpPost]
        public int AddLocation([FromBody] Model.Location value)
        {
            const string insertString = "insert into LocationData (longitude, latitude, userId, dateTimeInfo) values (@longitude, @latitude, @userId, @dateTimeInfo)";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertString, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@longitude", value.Longitude);
                    insertCommand.Parameters.AddWithValue("@latitude", value.Latitude);
                    insertCommand.Parameters.AddWithValue("@userId", value.UserId);
                    insertCommand.Parameters.AddWithValue("@dateTimeInfo", value.DateTimeInfo);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // PUT: api/Location/5
        [HttpPut("{id}")]
        public int UpdateLocation(int id, [FromBody] Model.Location value)
        {
            const string updateString =
                "update LocationData set longitude=@longitude, latitude=@latitude, userId=@userId, dateTimeInfo=@dateTimeInfo where id=@id;";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand updateCommand = new SqlCommand(updateString, databaseConnection))
                {
                    updateCommand.Parameters.AddWithValue("@longitude", value.Longitude);
                    updateCommand.Parameters.AddWithValue("@latitude", value.Latitude);
                    updateCommand.Parameters.AddWithValue("@userId", value.UserId);
                    updateCommand.Parameters.AddWithValue("@dateTimeInfo", value.DateTimeInfo);
                    updateCommand.Parameters.AddWithValue("@id", id);
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

    }
}
