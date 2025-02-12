using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinnerHelper.Api.Controllers;

[Route("[controller]")]
[Authorize]
public class DinnersController : ApiController
{
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}