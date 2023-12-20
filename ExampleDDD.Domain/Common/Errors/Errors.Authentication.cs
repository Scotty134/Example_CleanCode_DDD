using ErrorOr;

namespace ExampleDDD.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(code: "User.Authentication",
                                                                 description: "Invalid credentials.");
        }
    }
}
