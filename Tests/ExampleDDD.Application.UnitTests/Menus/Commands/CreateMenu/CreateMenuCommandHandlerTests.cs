using ExampleDDD.Application.Common.Interfaces.Persistence;
using ExampleDDD.Application.Menus.Commands.CreateMenu;
using ExampleDDD.Application.UnitTests.Menus.Commands.TestUtils;
using ExampleDDD.Application.UnitTests.Menus.Commands.TestUtils.Menus.Extensions;
using FluentAssertions;
using Moq;
using Xunit;

namespace ExampleDDD.Application.UnitTests.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandlerTests
    {
        private readonly CreateMenuCommandHandler _handler;
        private readonly Mock<IMenuRepository> _mockMenuRepository;

        public CreateMenuCommandHandlerTests()
        {
            _mockMenuRepository = new Mock<IMenuRepository>();
            _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);        
        }

        // T1: SUT - logical component we'are testing
        // T2: Scenario - what we'are testing
        // T3: Excepted outcome - what we expect the logical component to do
        [Theory]
        [MemberData(nameof(ValidCreateMenuCommands))]
        public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
        {
            // Act
            // Invoke the handler
            var result = await _handler.Handle(createMenuCommand, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.ValidateCreateFrom(createMenuCommand);
            _mockMenuRepository.Verify(m => m.Add(result.Value), Times.Once);
        }

        public static IEnumerable<object[]> ValidCreateMenuCommands()
        {
            yield return new[] { CreateMenuCommandUtils.CreateCommand() };
            yield return new[] { CreateMenuCommandUtils.CreateSectionsCommand(sectionCount: 3) };
            yield return new[] { CreateMenuCommandUtils.CreateSectionsCommand(sectionCount: 3, items: CreateMenuCommandUtils.CreateItemsCommand(itemCount: 3)) };
        }
    }
}
