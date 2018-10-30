using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBerthaRestConsumer.Model
{
    public class Environment
    {

        public int Id { get; set; }
        public decimal Oxygen { get; set; }
        public decimal Co2 { get; set; }
        public decimal Co { get; set; }
        public decimal Pm25 { get; set; }
        public decimal Pm10 { get; set; }
        public decimal Ozon { get; set; }
        public decimal DustParticles { get; set; }
        public decimal NitrogenDioxide { get; set; }
        public decimal SulphurDioxide { get; set; }
        public int UserId { get; set; }
        public DateTime DateTimeInfo { get; set; }

        

        public Environment()
        {
            
        }

        public Environment(int id, decimal oxygen, decimal co2, decimal co, decimal pm25, decimal pm10, decimal ozon, decimal dustParticles, decimal nitrogenDioxide, decimal sulphurDioxide, int userId, DateTime dateTimeInfo)
        {
            Id = id;
            Oxygen = oxygen;
            Co2 = co2;
            Co = co;
            Pm25 = pm25;
            Pm10 = pm10;
            Ozon = ozon;
            DustParticles = dustParticles;
            NitrogenDioxide = nitrogenDioxide;
            SulphurDioxide = sulphurDioxide;
            UserId = userId;
            DateTimeInfo = dateTimeInfo;
        }

        public override string ToString()
        {
            return Id + " " + Oxygen + " " + Co2 + " " + Co + " " + Pm25 + " " + Pm10 + " " + Ozon + " " + DustParticles + " " + NitrogenDioxide + " " + SulphurDioxide + " " + UserId + " " + DateTimeInfo;
        }
    }
}
