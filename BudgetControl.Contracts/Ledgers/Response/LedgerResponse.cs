
namespace BudgetControl.Contracts.Ledgers.Response;

public record LedgerResponse(Guid Id,
                             string Name,
                             string Type,
                             Guid UserId,
                             List<LedgerCategoryResponse> Categories);