using Code_Kata.Model;
using Code_Kata.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace Code_Kata
{
    class KataConcrete: IKata
    {
        public void ReadWordFile(string path, List<Trip> trips)
        {
            int counter = 0;
            string line = string.Empty;
            string inputLine = string.Empty;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                ReadTripAttributes(line, trips);
                counter++;
            }
            file.Close();
        }
        public void ReadTripAttributes(string textLine, List<Trip> trips)
        {
            string[] words = textLine.Split(' ');
            if (textLine.Contains("Driver"))
            {
                Trip trip = new Trip();
                trip.DriverName = words[1];
                trips.Add(trip);
            }
            else
            {
                if (trips.Where(i => i.TripCount > 0 && i.DriverName == words[1]).Count() > 0)
                {
                    Trip trip = new Trip();
                    trip.DriverName = words[1];
                    trip.StartTime = TimeSpan.Parse(words[2]);
                    trip.StopTime = TimeSpan.Parse(words[3]);
                    trip.MilesDriven = float.Parse(words[4]);
                    trips.Add(trip);
                }
                else
                {
                    Trip trip = trips.Where(i => i.DriverName == words[1]).FirstOrDefault();
                    trip.DriverName = words[1];
                    trip.StartTime = TimeSpan.Parse(words[2]);
                    trip.StopTime = TimeSpan.Parse(words[3]);
                    trip.MilesDriven = float.Parse(words[4]);
                    trip.TripCount += 1;
                }
            }
        }
        public void GenerateTripResult(List<Trip> trips, List<TripValues> tripValues)
        {
            foreach (Trip trip in trips)
            {
                if (tripValues.Where(i => i.DriverName == trip.DriverName).Count() > 0)
                {
                    TripValues existValues = tripValues.Where(i => i.DriverName == trip.DriverName).FirstOrDefault();
                    existValues.TotalTime += Helper.TimeInHours(trip.StartTime, trip.StopTime);
                    existValues.TotalDistance += (int)Math.Round(trip.MilesDriven);
                    existValues.DriverName = trip.DriverName;
                    existValues.AverageSpeed = (int)Math.Round(Helper.CalculateAverageSpeed(existValues.TotalTime, existValues.TotalDistance));
                }
                else
                {
                    TripValues tripValue = new TripValues();
                    tripValue.DriverName = trip.DriverName;
                    tripValue.TotalDistance = (int)Math.Round(trip.MilesDriven);
                    tripValue.TotalTime = Helper.TimeInHours(trip.StartTime, trip.StopTime);
                    tripValue.AverageSpeed = (int)Math.Round(Helper.CalculateAverageSpeed(tripValue.TotalTime, trip.MilesDriven));
                    if (ValidateTrip.CheckValidTrip(tripValues, tripValue))
                    {
                        tripValues.Add(tripValue);
                    }
                }
            }
        }
        public void GenerateWordReport(List<TripValues> tripValues)
        {
            //string fileName = @"C:\exempleWord.docx";
            string fileName = ConfigurationManager.AppSettings["downloadFilePath"];
            var doc = DocX.Create(fileName);
            string textParagraph = null;
            tripValues = tripValues.OrderByDescending(i => i.TotalDistance).ToList();

            foreach (TripValues trip in tripValues)
            {
                if (trip.TotalDistance != 0)
                {
                    textParagraph += trip.DriverName + ": " + trip.TotalDistance.ToString() + " miles" + " @" + trip.AverageSpeed.ToString() + " mph" + Environment.NewLine;
                }
                else
                {
                    textParagraph += trip.DriverName + ": " + trip.TotalDistance.ToString() + " miles" + Environment.NewLine;
                }
            }
            doc.InsertParagraph(textParagraph);
            doc.Save();
        }
    }
}
