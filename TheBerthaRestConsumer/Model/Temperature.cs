using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBerthaRestConsumer.Model
{
    public class Temperature
    {
        public int Id { get; set; }
        public decimal Temp { get; set; }
        public DateTime DT { get; set; }

        public Temperature(int id, decimal temp, DateTime dT)
        {
            Id = id;
            Temp = temp;
            DT = dT;
        }

        public Temperature()
        {
            
        }

        public override string ToString()
        {
            return $"{Id}, {Temp}, {DT}";
        }
    }

}
