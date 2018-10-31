using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBerthaRestConsumer.Model
{
    public class Health
    {
        public int Id { get; set; }
        public int BloodPressureUpper { get; set; }
        public int BloodPressureDown { get; set; }
        public int HeartRate { get; set; }
        public decimal Temperature { get; set; }
        public int UserId { get; set; }
        public DateTime DateTimeInfo { get; set; }

        public Health()
        {

        }

        public Health(int id, int bloodPressureUpper, int bloodPressureDown, int heartRate, decimal temperature, int userId, DateTime dateTimeInfo)
        {
            Id = id;
            BloodPressureUpper = bloodPressureUpper;
            BloodPressureDown = bloodPressureDown;
            HeartRate = heartRate;
            Temperature = temperature;
            UserId = userId;
            DateTimeInfo = dateTimeInfo;
        }

        public override string ToString()
        {
            return Id + BloodPressureDown + BloodPressureUpper + HeartRate + Temperature + UserId + DateTimeInfo.ToString();
        }
    }
}
