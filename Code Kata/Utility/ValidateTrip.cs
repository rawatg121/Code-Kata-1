using Code_Kata.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Kata.Utility
{
    class ValidateTrip
    {
        public static bool CheckValidTrip(List<TripValues> tripValues, TripValues tripValue)
        {
            if (tripValue.AverageSpeed > 5 || tripValue.AverageSpeed < 100)
            {
                return true;
            }
            return false;
        }

    }
}
