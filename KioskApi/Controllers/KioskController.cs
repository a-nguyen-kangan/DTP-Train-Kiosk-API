using Microsoft.AspNetCore.Mvc;
using KioskLib;

namespace KioskApi.Controllers;

[ApiController]
[Route("v1")]
public class KioskController : ControllerBase
{

    [HttpGet("search")]
    public string Search()
    {
        return new TrainFetch().Search("Richmond Station").ExpectedArrival;
    }

    [HttpGet("stops/{route}/{results}")]
    public string Stops(int destination, int results)
    {
        return "5:1|8:2|12:1";
    }
}
