using ErrorOr;
using ExampleDDD.Application.Common.Interfaces.Persistence;
using ExampleDDD.Domain.Common.ValueObjects;
using ExampleDDD.Domain.HostAggregate.ValueObjects;
using ExampleDDD.Domain.MenuAggregate;
using ExampleDDD.Domain.MenuAggregate.Entities;
using MediatR;

namespace ExampleDDD.Application.Menus.Commands.CreateMenu
{
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
            // Create Menu
            var menu = Menu.Create(
                hostId: HostId.Create(Guid.Parse(request.HostId)),
                name: request.Name,
                description: request.Description,
                rating: AverageRating.CreateNew(),
                sections: request.Sections.ConvertAll(section => MenuSection.Create(
                    section.Name,
                    section.Description,
                    section.Items.ConvertAll(item => MenuItem.Create(item.Name, item.Description))
                    ))
                );
            // Persist Menu
            _menuRepository.Add(menu);
            // Return Menu
            return menu;
        }
    }
}
