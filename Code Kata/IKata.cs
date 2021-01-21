using Code_Kata.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Kata
{
    interface IKata
    {
        void ReadWordFile(string path, List<Trip> trips);
        void GenerateTripResult(List<Trip> trips, List<TripValues> tripValues);
        void GenerateWordReport(List<TripValues> tripValues);
    }
}
