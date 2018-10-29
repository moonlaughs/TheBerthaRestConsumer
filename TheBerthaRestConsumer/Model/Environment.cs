﻿using System;
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
        public string Co { get; set; }
        public string Pm25 { get; set; }
        public string Pm10 { get; set; }
        public string Ozon { get; set; }
        public string DustParticles { get; set; }
        public string NitrogenDioxide { get; set; }
        public string SulphurDioxide { get; set; }
        public int UserId { get; set; }
        public DateTime DateTimeInfo { get; set; }

        public Environment(int id, string oxygen, string co2,string co, string pm25, string pm10, string ozon, string dustParticles, string nitrogenDioxide, string sulphurDioxide, int userId, DateTime dateTimeInfo)
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
            SulphurDioxide = SulphurDioxide;
            UserId = userId;
            DateTimeInfo = dateTimeInfo;
        }

        public Environment()
        {
            
        }

        public override string ToString()
        {
            return Id + Oxygen + Co2 + Co + Pm25 + Pm10 + Ozon + DustParticles + NitrogenDioxide + SulphurDioxide + UserId + DateTimeInfo;
        }
    }
}