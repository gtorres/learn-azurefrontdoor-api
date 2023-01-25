using Bogus;
using FrontDoorAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FrontDoorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {


        [HttpGet]
        public IActionResult Get()
        {
            var testUsers = new Faker<UserViewModel>()
                                                     .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                                                     .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                                                     .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
                                                     .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                                                     .Generate(100);


           return Ok(testUsers);
        }
        [HttpGet]
        [Route("cached")]
        [ResponseCache(Duration = 30)]
        public IActionResult GetCached()
        {
            var testUsers = new Faker<UserViewModel>()
                                                     .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                                                     .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                                                     .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
                                                     .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                                                     .Generate(100);


            return Ok(testUsers);
        }
    }
}