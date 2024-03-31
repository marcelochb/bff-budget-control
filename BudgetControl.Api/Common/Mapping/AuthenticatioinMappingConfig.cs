using BudgetControl.Application.Ledgers.Contratcts;
using BudgetControl.Contracts.Ledgers.Response;
using Mapster;

namespace BudgetControl.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // config.NewConfig<LedgerResult, LedgerResponse>()
        // .Map(dest => dest.Id, src => src.Id)
        // .Map(dest => dest.UserId, src => src.UserId);
        // config.NewConfig<LedgerCategoryResult, LedgerCategoryResponse>()
        // .Map(dest => dest.Id, src => src.Id);
        // config.NewConfig<CategoryGroupResult, CategoryGroupResponse>()
        // .Map(dest => dest.Id, src => src.Id);

    }
}