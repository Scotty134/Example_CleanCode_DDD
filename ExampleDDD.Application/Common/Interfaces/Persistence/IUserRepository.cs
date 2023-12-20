using ExampleDDD.Domain.Entities;

namespace ExampleDDD.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        public User? GetUserByEmail(string email);
        public void Add(User user);
    }
}
