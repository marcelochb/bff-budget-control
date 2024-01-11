using BudgetControl.Infrastructure.Persistence;
using BudgetControl.Infrastructure.Services;
using BudgetControl.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BudgetControl.Interfaces.Persistence.Authentication;
using BudgetControl.Domain.Entities;
using BudgetControl.Interfaces.Persistence.Ledger;

namespace BudgetControl.Infrastructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator<User>, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository<User>, UserRepository>();
        services.AddScoped<ILedgerRepository<Ledger>, LedgerRepository>();
        return services;
    }
}