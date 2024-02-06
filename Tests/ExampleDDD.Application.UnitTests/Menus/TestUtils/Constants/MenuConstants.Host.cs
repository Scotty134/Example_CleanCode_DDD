using ExampleDDD.Domain.HostAggregate.ValueObjects;

namespace ExampleDDD.Application.UnitTests.Menus.TestUtils.Constants
{
    public static partial class MenuConstants
    {
        public static class Host
        {
            public static readonly HostId Id = HostId.Create(Guid.NewGuid());
        }
    }
}
