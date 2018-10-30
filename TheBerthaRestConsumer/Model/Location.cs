using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBerthaRestConsumer.Model
{
    public class Location
    {
        public Location(int id, string longitude, string latitude, int userId, DateTime dateTimeInfo)
        {
            Id = id;
            Longitude = longitude;
            Latitude = latitude;
            UserId = userId;
            DateTimeInfo = dateTimeInfo;
        }

        public int Id { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int UserId { get; set; }
        public DateTime DateTimeInfo { get; set; }

        public Location()
        {

        }


        public override string ToString()
        {
            return Id + Longitude + Latitude + UserId + DateTimeInfo;
        }

    }
}
