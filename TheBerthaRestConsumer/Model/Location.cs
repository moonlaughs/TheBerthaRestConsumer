using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBerthaRestConsumer.Model
{
    public class Location
    {
        public Location (int id, decimal longitude, decimal latitude, int userId, DateTime dateTimeInfo)
        {
            Id = id;
            Longitude = longitude;
            Latitude = latitude;
            UserId = userId;
            DateTimeInfo = dateTimeInfo;
        }

        public int Id { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int UserId { get; set; }
        public DateTime DateTimeInfo { get; set; }

        public Location()
        {

        }
            

        public override string ToString()
        {
            return Id + " "+ Longitude + " " + Latitude + " " + UserId + " " + DateTimeInfo;
        }

    }
}
