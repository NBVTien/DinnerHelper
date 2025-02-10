using ErrorOr;

namespace DinnerHelper.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredential => Error.Validation(
            code: "Authentication.InvalidCredential",
            description: "Invalid username or password.");
    }
}