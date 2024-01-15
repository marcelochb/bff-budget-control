using BudgetControl.Application.Contratcts;
using BudgetControl.Application.Services;
using BudgetControl.Interfaces.Services;
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