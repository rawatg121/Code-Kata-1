using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Kata.Model
{
    public class Trip
    {
        public string DriverName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan StopTime { get; set; }
        public float MilesDriven { get; set; }
        public int  TripCount { get; set; }
    }
}
