using BudgetControl.Application.Ledgers.Contratcts;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using Mapster;

namespace BudgetControl.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Ledger, LedgerResult>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.UserId, src => src.UserId.Value);
        config.NewConfig<LedgerCategory, LedgerCategoryResult>()
        .Map(dest => dest.Id, src => src.Id.Value);
        config.NewConfig<CategoryGroup, CategoryGroupResult>()
        .Map(dest => dest.Id, src => src.Id.Value);
    }
}