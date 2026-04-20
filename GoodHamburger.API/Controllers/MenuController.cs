using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.API.Controllers;

[ApiController]
[Route("menu")]
public class MenuController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Sandwiches = new[]
            {
                new { Name = "X Burger", Price = 5.00 },
                new { Name = "X Egg", Price = 4.50 },
                new { Name = "X Bacon", Price = 7.00 }
            },
            Sides = new[]
            {
                new { Name = "Fries", Price = 2.00 },
                new { Name = "Soda", Price = 2.50 }
            }
        });
    }
}