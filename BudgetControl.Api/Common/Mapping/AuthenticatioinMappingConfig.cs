using BudgetControl.Application.Contratcts;
using BudgetControl.Contracts.Authentication.Response;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Domain.UserAggregate.Entities;
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
        config.NewConfig<UserConfig, UserConfigResponse>()
        .Map(dest => dest.LedgerId, src => src.LedgerId.Value);
    }
}