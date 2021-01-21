using Code_Kata.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Kata
{
    class KataConsumer
    {
        IKata _kata;
        public KataConsumer()
        {

        }
        public KataConsumer(IKata kata)
        {
            _kata = kata;
        }
        public void StartTrip()
        {
            string path = ConfigurationManager.AppSettings["filePath"];
            List<Trip> trips = new List<Trip>();
            List<TripValues> tripValues = new List<TripValues>();
            _kata.ReadWordFile(path, trips);
            _kata.GenerateTripResult(trips, tripValues);
            _kata.GenerateWordReport(tripValues);
        }
    }
}
