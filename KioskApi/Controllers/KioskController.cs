using Microsoft.AspNetCore.Mvc;
using KioskLib;

namespace KioskApi.Controllers;

[ApiController]
[Route("v1")]
public class KioskController : ControllerBase
{
    [HttpGet("search/{station}")]
    public string Search(string station)
    {
        return new TrainFetch().Search(station);
    }

    [HttpGet("departures/{stopID}/{destinationID}")]
    public string Stops(int stopID, int destinationID)
    {
        //return new TrainFetch().Departures(stopID, destinationID, results);
        return "5:1:E"; // time(minutes):platform:service
    }
}
