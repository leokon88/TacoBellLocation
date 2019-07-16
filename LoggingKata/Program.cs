using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;


namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray(); // lists of tacobell location that conforms to Itrackable
            ITrackable locationA = new TacoBell();
            ITrackable locationB = new TacoBell();
            ITrackable location1 = null;
            ITrackable location2 = null;
            double farDistance = 0;
            double distance;
            for (int i = 0; i < locations.Count(); i++)
            {
                locationA = locations[i];
                var orgin = new GeoCoordinate(locationA.Location.Latitude, locationA.Location.Longitude);

                for (int j = 1; j < locations.Count(); j++)
                {
                    locationB = locations[j];

                    var destination = new GeoCoordinate(locationB.Location.Latitude, locationB.Location.Longitude);

                    distance = orgin.GetDistanceTo(destination);

                    if (distance > farDistance)
                    {
                        farDistance = distance * 0.621371;
                        location1 = locationA;
                        location2 = locationB;
                    }
                }
            }
            Console.WriteLine($"Farthest distance = {farDistance} miles between {location1.Name} and {location2.Name}");
        }
    }
}