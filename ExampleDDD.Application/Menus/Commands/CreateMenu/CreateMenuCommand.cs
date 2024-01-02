using ErrorOr;
using ExampleDDD.Domain.MenuAggregate;
using MediatR;

namespace ExampleDDD.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(
        string Name,
        string Description,
        string HostId,
        List<MenuSectionCommand> Sections
    ) : IRequest<ErrorOr<Menu>>;

    public record MenuSectionCommand(
        string Name,
        string Description,
        List<MenuItemCommand> Items
    );

    public record MenuItemCommand(
        string Name,
        string Description
    );
}
