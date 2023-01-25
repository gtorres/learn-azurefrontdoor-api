using Bogus;
using FrontDoorAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FrontDoorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitoringController : ControllerBase
    {


        [HttpGet]
        public IActionResult Get()
        {
           return Ok();
        }
       
    }
}