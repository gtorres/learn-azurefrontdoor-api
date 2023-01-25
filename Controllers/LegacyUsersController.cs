using Bogus;
using FrontDoorAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FrontDoorAPI.Controllers
{
    [ApiController]
    [Route("api/legacy/[controller]")]
    public class LegacyUsersController : ControllerBase
    {


        [HttpGet]
        public IActionResult Get()
        {
            var testUsers = new Faker<UserViewModel>()
                                                     .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                                                     .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                                                     .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
                                                     .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                                                     .Generate(2);


           return Ok(testUsers);
        }
      
    }
}