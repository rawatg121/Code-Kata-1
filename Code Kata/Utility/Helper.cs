using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Kata.Utility
{
    public class Helper
    {
        public static double CalculateAverageSpeed(double timeInHours, float distance)
        {
            double averageSpeed = distance / timeInHours;
            return averageSpeed;
        }
        public static double TimeInHours(TimeSpan startTime, TimeSpan endTime)
        {
            TimeSpan totalTimeTaken = endTime.Subtract(startTime);
            double timeInHours = (totalTimeTaken.TotalHours);
            return timeInHours;
        }

    }
}
