using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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
        return JsonSerializer.Serialize(new TrainFetch().Departures(stopID, destinationID));
    }
}
