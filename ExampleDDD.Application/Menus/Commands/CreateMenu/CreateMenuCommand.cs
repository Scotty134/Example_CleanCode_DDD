using ErrorOr;
using ExampleDDD.Domain.MenuAggregate;
using MediatR;

namespace ExampleDDD.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(
        string Name,
        string Description,
        string HostId,
        List<CreateMenuSectionCommand> Sections
    ) : IRequest<ErrorOr<Menu>>;

    public record CreateMenuSectionCommand(
        string Name,
        string Description,
        List<CreateMenuItemCommand> Items
    );

    public record CreateMenuItemCommand(
        string Name,
        string Description
    );
}
