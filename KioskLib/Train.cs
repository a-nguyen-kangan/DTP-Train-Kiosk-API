using System.Text.Json;
namespace KioskLib;

public class TrainList
{
    public List<Train>? departures { get; set; }
}

public class Train
{
    public int? run_id { get; set; }
    public int? direction_id { get; set; }
    public string? estimated_departure_utc { get; set; }
    public string? platform_number { get; set; }
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
    public Train Departures(int stopID, int destinationID)
    {
        //string time = DateTime.UtcNow.Date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
        string url = $"/v3/departures/route_type/{route_type}/stop/{stopID}?direction_id={destinationID}&max_results=10&devid={devid}";
        Console.WriteLine(JsonSerializer.Deserialize<TrainList>(Request(url).Result).departures[0].estimated_departure_utc);
        return JsonSerializer.Deserialize<TrainList>(Request(url).Result).departures[0];
    }
}