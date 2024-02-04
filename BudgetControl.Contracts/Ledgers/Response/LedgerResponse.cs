using BudgetControl.Contracts.Authentication.Response;

namespace BudgetControl.Contracts.Ledgers.Response;

public record LedgerResponse(Guid Id,
                             string Name,
                             string Type,
                             UserResponse User,
                             List<LedgerCategoryResponse> Categories);