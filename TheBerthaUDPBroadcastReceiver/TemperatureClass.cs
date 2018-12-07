using System;
using System.Collections.Generic;
using System.Text;

namespace TheBerthaUDPBroadcastReceiver
{
   public class TemperatureClass
    {
        public int Id { get; set; }
        public string Temp { get; set; }
        public DateTime DT { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Temp}, {DT}";
        }
    }
}
