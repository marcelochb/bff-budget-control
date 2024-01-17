using BudgetControl.Contracts.Authentication.Response;
using Mapster;

namespace BudgetControl.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        // .Map(dest => dest.User.Config.LedgerId, src => src.User.Config.LedgerId);

        // config.NewConfig<User, UserResponse>()
        // .Map(dest => dest.Config, src => src.Config);
        // config.NewConfig<Config, ConfigResponse>()
        // .Map(dest => dest.LedgerId, src => src.LedgerId);
    }
}