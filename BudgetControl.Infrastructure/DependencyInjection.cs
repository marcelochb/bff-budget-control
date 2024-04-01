using BudgetControl.Infrastructure.Persistence;
using BudgetControl.Infrastructure.Services;
using BudgetControl.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BudgetControl.Interfaces.Persistence.Authentication;
using BudgetControl.Interfaces.Persistence;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Domain.LedgerAggregate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using BudgetControl.Domain.LedgerAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using BudgetControl.Infrastructure.Persistence.Repositories;
using BudgetControl.Infrastructure.Persistence.Interceptors;
using BudgetControl.Domain.ConfigAggregate;

namespace BudgetControl.Infrastructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddPersistance();
        return services;
    }
    public static IServiceCollection AddPersistance(
    this IServiceCollection services)
    {
        // var mongodb = new MongoClient("mongodb://localhost:27017").GetDatabase("BudgetControl");
        services.AddDbContext<BudgetControlDbContext>(options =>
        {
            // options.UseMongoDB(mongodb.Client,mongodb.DatabaseNamespace.DatabaseName);
            options.UseSqlServer("Server=localhost;Database=BudgetControl;User Id=SA;Password=slMchb2@11;TrustServerCertificate=True;");
        });

        services.AddScoped<PublishDomainEventsInterceptors>();
        services.AddScoped<IUserRepository<User>, UserRepository>();
        services.AddScoped<ILedgerRepository<Ledger>, LedgerRepository>();
        services.AddScoped<ICategoryRepository<LedgerCategory>, CategoryRepository>();
        services.AddScoped<IConfigRepository<Config>, ConfigRepository>();
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