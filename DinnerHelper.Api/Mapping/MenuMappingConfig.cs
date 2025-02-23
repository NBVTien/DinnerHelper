using DinnerHelper.Application.Menus.Commands.CreateMenu;
using DinnerHelper.Contracts.Menus;
using DinnerHelper.Domain.Menu;
using DinnerHelper.Domain.Menu.Entities;
using Mapster;

namespace DinnerHelper.Api.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(d => d.Value).ToList())
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(r => r.Value).ToList());

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
        
        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}