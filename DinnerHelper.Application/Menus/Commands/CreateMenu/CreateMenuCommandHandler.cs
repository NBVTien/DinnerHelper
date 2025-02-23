using System.Diagnostics;
using DinnerHelper.Application.Common.Interfaces.Persistence;
using DinnerHelper.Domain.Host.ValueObjects;
using DinnerHelper.Domain.Menu;
using DinnerHelper.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace DinnerHelper.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var menu = Menu.Create(
            request.Name,
            request.Description,
            request.Sections.ConvertAll(
                section => MenuSection.Create(
                    section.Name,
                    section.Description,
                    section.Items.ConvertAll(
                        item => MenuItem.Create(
                            item.Name,
                            item.Description)))),
            HostId.Create(new Guid(request.HostId)));
        
        _menuRepository.Add(menu);
        
        return menu;
    }
}