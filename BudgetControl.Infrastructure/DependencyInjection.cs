using BudgetControl.Infrastructure.Persistence;
using BudgetControl.Infrastructure.Services;
using BudgetControl.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BudgetControl.Interfaces.Persistence.Authentication;
using BudgetControl.Interfaces.Persistence.Ledgers;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Domain.LedgerAggregate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using BudgetControl.Interfaces.Persistence.Categories;
using BudgetControl.Domain.LedgerAggregate.Entities;

namespace BudgetControl.Infrastructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository<User>, UserRepository>();
        services.AddScoped<ILedgerRepository<Ledger>, LedgerRepository>();
        services.AddScoped<ICategoryRepository<LedgerCategory>, CategoryRepository>();
        return services;
    }

        public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName,jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator<User>, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret))
        });
        return services;
    }
}