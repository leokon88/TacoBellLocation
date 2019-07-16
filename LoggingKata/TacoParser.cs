namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            if (line == null)
            {
                logger.LogError("Error - data is null");
                return null;
            }
            else
            {
                var cells = line.Split(',');

                if (cells.Length < 3 || !double.TryParse(cells[0], out double latitude) || !double.TryParse(cells[1], out double longitude))
                {
                    logger.LogError("Error -incorrect data format provided");
                    return null;
                }
                else
                {
                    TacoBell tacoBellLocation = new TacoBell(latitude, longitude, cells[2].ToString());
                    return tacoBellLocation;
                }
            }
        }
    }
}