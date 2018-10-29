using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBerthaRestConsumer.Model
{
    public class Environment
    {

        public int Id { get; set; }
        public string Oxygen { get; set; }
        public string Co2 { get; set; }
        public string Pm25 { get; set; }
        public string Pm10 { get; set; }
        public string Ozone { get; set; }
        public string DustParticles { get; set; }
        public string NitrogenDioxide { get; set; }
        public string SulphurDioxide { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }

        public Environment(int id, string oxygen, string co2, string pm25, string pm10, string ozone, string dustParticles, string nitrogenDioxide, string sulphurDioxide, int userId, DateTime dateTime)
        {
            Id = id;
            Oxygen = oxygen;
            Co2 = co2;
            Pm25 = pm25;
            Pm10 = pm10;
            Ozone = ozone;
            DustParticles = dustParticles;
            NitrogenDioxide = nitrogenDioxide;
            SulphurDioxide = sulphurDioxide;
            UserId = userId;
            DateTime = dateTime;
        }

        public Environment()
        {
            
        }

        public override string ToString()
        {
            return Id + Oxygen + Co2 + Pm25 + Pm10 + DustParticles + NitrogenDioxide + SulphurDioxide + UserId + DateTime;
        }
    }
}
