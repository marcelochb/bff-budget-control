using BudgetControl.Contracts.Authentication.Response;
using Mapster;

namespace BudgetControl.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // config.NewConfig<AuthenticationResult, AuthenticationResponse>();
    }
}