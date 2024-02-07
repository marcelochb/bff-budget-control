using ErrorOr;

namespace BudgetControl.Domain.Common.Errors;

public static partial class Errors {
    public static class Ledger {
        public static Error DuplicateName => Error.Conflict(
            code: "ledger.duplicate_name",
            description: "Name already exists");
        public static Error NotFound => Error.Conflict(
            code: "ledger.not_found",
            description: "Ledger not found");
    }
}