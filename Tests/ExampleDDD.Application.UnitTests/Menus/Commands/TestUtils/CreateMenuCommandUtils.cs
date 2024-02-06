using ExampleDDD.Application.Menus.Commands.CreateMenu;
using ExampleDDD.Application.UnitTests.Menus.TestUtils.Constants;

namespace ExampleDDD.Application.UnitTests.Menus.Commands.TestUtils
{
    public static class CreateMenuCommandUtils
    {
        public static CreateMenuCommand CreateCommand(
            List<CreateMenuSectionCommand>? sections = null) =>
            new CreateMenuCommand(                
                MenuConstants.Menu.Name,
                MenuConstants.Menu.Desciption,
                MenuConstants.Host.Id.ToString()!,
                sections ?? CreateSectionsCommand());

        public static List<CreateMenuSectionCommand> CreateSectionsCommand(
            int sectionCount = 1, 
            List<CreateMenuItemCommand>? items = null) =>
            Enumerable.Range(0, sectionCount)
            .Select(index => new CreateMenuSectionCommand(
                MenuConstants.Menu.SectionNameFromIndex(index),
                MenuConstants.Menu.SectionDescriptionFromIndex(index),
                items ?? CreateItemsCommand()))
            .ToList();

        public static List<CreateMenuItemCommand> CreateItemsCommand(int itemCount = 1) =>
            Enumerable.Range(0, itemCount)
            .Select(index => new CreateMenuItemCommand(
                MenuConstants.Menu.ItemNameFromIndex(index),
                MenuConstants.Menu.ItemDescriptionFromIndex(index)))
            .ToList();
    }
}
