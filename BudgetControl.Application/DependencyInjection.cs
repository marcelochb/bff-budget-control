using BudgetControl.Application.Services.Authentication;
using BudgetControl.Interfaces.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetControl.Application;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService<AuthenticationResult>, AuthenticationService>();
        return services;

    }
}