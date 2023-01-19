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

    [HttpGet("stops/{destination}/{results}")]
    public string Stops(int destination, int results)
    {
        return "5:1:E|8:2:LTD|12:1:ALL"; // time(minutes):platform:service
    }
}
