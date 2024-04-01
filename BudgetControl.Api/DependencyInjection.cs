using BudgetControl.Api.Common.Mapping;

namespace BudgetControl.Api;


public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddApiMappings();
        return services;
    }
}