using Microsoft.Extensions.Configuration;

namespace KioskLib;

public class Train
{
    public int Platform { get; }
    public int DirectionID { get; }
    public string ExpectedArrival { get; }
    public Train(int platform, int directionID, string expectedArrival)
    {
        Platform = platform;
        DirectionID = directionID;
        ExpectedArrival = expectedArrival;
    }

}

public abstract class Fetch
{
    protected string devid = "id";
    protected string devkey = "signature";
    protected string ApiServer = "http://timetableapi.ptv.vic.gov.au/v3";
    protected async Task<string> Request(string url)
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync(url);
        return response;
    }
    protected void init()
    {
        var appConfig = new ConfigurationBuilder()
        .AddUserSecrets<Fetch>()
        .Build();
        devid = appConfig["devid"];
        devkey = appConfig["devkey"];
    }
}

public class TrainFetch : Fetch
{
    private int route_type = 0;
    public Train Search(string station)
    {
        string url = $"{ApiServer}/search/{station}?route_types={route_type}&devid={devid}";
        crypto.HMACSHA1(url, devkey);
        _ = Request(url).Result;
        return new Train(1, 1, "1");
    }
}