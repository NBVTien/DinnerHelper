using Microsoft.AspNetCore.Mvc;

namespace DinnerHelper.Api.Controllers;

public class ErrorsController : ApiController

{
    [Route("/error")]
    public IActionResult Error() => Problem();
}