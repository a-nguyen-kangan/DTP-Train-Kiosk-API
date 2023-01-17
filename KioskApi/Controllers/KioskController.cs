using Microsoft.AspNetCore.Mvc;
using KioskLib;

namespace KioskApi.Controllers;

[ApiController]
[Route("v1")]
public class KioskController : ControllerBase
{

    [HttpGet("Search")]
    public string Search()
    {
        return new TrainFetch().Search("Richmond Station").ExpectedArrival;
    }
}
