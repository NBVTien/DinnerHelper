using Microsoft.AspNetCore.Mvc;

namespace DinnerHelper.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error() => Problem();
}