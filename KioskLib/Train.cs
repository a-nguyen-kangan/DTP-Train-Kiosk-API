namespace KioskLib;

public class Train
{
    public int Platform { get; }
    public int DirectionID { get; }
    public string ExpectedArrival { get; }
    public int Sequence { get; }
    public Train(int platform, int directionID, string expectedArrival, int sequence)
    {
        Platform = platform;
        DirectionID = directionID;
        ExpectedArrival = expectedArrival;
        Sequence = sequence;
    }

}

public class TrainFetch : Fetch
{
    public TrainFetch()
    {
        init();
    }
    private int route_type = 0;
    public string Search(string station)
    {
        string url = $"/v3/search/{station}?route_types={route_type}&devid={devid}";
        return Request(url).Result;
        //return new Train(1, 1, "1", 0);
    }
    public string Departures(int stopID, int destinationID, int results)
    {
        string time = DateTime.UtcNow.Date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
        string url = $"/v3/departures/route_type/{route_type}/stop/{stopID}?direction_id={destinationID}&date_utc={time}&max_results={results}&devid={devid}";
        return Request(url).Result;
        
    }
}