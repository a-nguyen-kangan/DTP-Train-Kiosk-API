using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
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

public abstract class Fetch
{
    protected string devid;
    protected string devkey;
    protected string ApiServer = "http://timetableapi.ptv.vic.gov.au";
    protected async Task<string> Request(string url)
    {
        url = url.Replace(" ", "%20");
        url = ApiServer+url+SignData(url, devkey);
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
    public string SignData(string request, string key)
    {
        var encoding = new System.Text.ASCIIEncoding();
        byte[] keyBytes = encoding.GetBytes(key);
        byte[] requestBytes = encoding.GetBytes(request);
        using (var hmacsha1 = new HMACSHA1(keyBytes))
        {
            var Signature = hmacsha1.ComputeHash(requestBytes);
            return $"&signature={Convert.ToHexString(Signature).ToUpper()}";
        }
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
}