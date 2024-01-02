using ExampleDDD.Application.Menus.Commands.CreateMenu;
using ExampleDDD.Contracts.Menus;
using ExampleDDD.Domain.MenuAggregate;
using ExampleDDD.Domain.MenuAggregate.Entities;
using Mapster;

namespace ExampleDDD.Api.Common.Mapping
{
    public class MenuMappingConfig: IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                //.Map(dest => dest.AverageRating, src => {
                //    return src.AverageRating.NumRating > 0 ? src.AverageRating.Value : null;
                //})
                .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.DinnersIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
                .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuId => menuId.Value));

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

        }
    }
}
