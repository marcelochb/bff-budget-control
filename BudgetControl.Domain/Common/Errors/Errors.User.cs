using ErrorOr;

namespace BudgetControl.Domain.Common.Errors;

public static partial class Errors {
    public static class User {
        public static Error DuplicateEmail => Error.Conflict(
            code: "user.duplicate_email",
            description: "Email already exists");
        public static Error DuplicateName => Error.Conflict(
            code: "user.duplicate_name",
            description: "Name already exists");
        public static Error NotFound => Error.Conflict(
            code: "user.not_found",
            description: "User not found");
    }
}