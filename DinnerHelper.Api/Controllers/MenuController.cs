using DinnerHelper.Application.Menus.Commands.CreateMenu;
using DinnerHelper.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerHelper.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenuController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public MenuController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(string hostId, CreateMenuRequest request)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResult = await _mediator.Send(command);
        return createMenuResult.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            Problem);
    }
}