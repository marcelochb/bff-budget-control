using BudgetControl.Contracts.Ledgers.Response;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using Mapster;

namespace BudgetControl.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        // .Map(dest => dest.User.Config.LedgerId, src => src.User.Config.LedgerId.Value);

        // config.NewConfig<User, UserResponse>()
        // .Map(dest => dest.Config, src => src.Config);
        // config.NewConfig<ConfigResult, UserConfigResponse>()
        // .Map(dest => dest.LedgerId, src => src.ledgerId);
        config.NewConfig<Ledger, LedgerResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.UserId, src => src.UserId.Value);
        config.NewConfig<LedgerCategory, LedgerCategoryResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);
        config.NewConfig<CategoryGroup, CategoryGroupResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

    }
}