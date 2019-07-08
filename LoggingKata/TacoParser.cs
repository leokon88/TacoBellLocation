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
            logger.LogInfo("Begin parsing");
            var cells = line.Split(',');

            

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                return null; // TODO Implement
                // Log that and return null
            }
            // Do not fail if one record parsing fails, return null
            else
            {
                TacoBell taco = new TacoBell( double.Parse(cells[0]), double.Parse(cells[0]), cells[2].ToString());
                return taco;
            }
        }
    }
}