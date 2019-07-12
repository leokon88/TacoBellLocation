﻿using System;
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
            ITrackable loc1 = new TacoBell();
            ITrackable loc2 = new TacoBell();
            ITrackable location1=null;
            ITrackable location2=null;
            double farDistance=0;
            double distance;
            for (int i = 0; i < locations.Count(); i++)
            {
                loc1 = locations[i];
                var orgin = new GeoCoordinate(loc1.Location.Latitude, loc1.Location.Longitude);

                for (int j = 1; j < locations.Count(); j++)
                {
                    loc2 = locations[j];

                    var destination = new GeoCoordinate(loc2.Location.Latitude, loc2.Location.Longitude);

                    distance = orgin.GetDistanceTo(destination);

                    if (distance > farDistance)
                    {
                        farDistance = distance;
                       location1 = loc1;
                       location2 = loc2;
                    }
                    
                }

            }
            Console.WriteLine($"Farthest distance = {farDistance} is between {location1.Name} and {location2.Name}");


            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.

            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            // Create a `double` variable to store the distance

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
            // Create a new Coordinate with your locB's lat and long
            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.

            // HINT:  You'll need two nested forloops
        }
    }
}