using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    class TacoBell : ITrackable
    {
        public Point Location { get; set; }
        public string Name { get; set; }


        public TacoBell(double lat, double lng, string name)
        {
            Location = new Point
            {
                Latitude = lat,
                Longitude = lng
            };
            Name = name;
        }

        public TacoBell()
        {

        }
    }
}
