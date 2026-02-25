using Microsoft.Extensions.DependencyInjection;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Services;
using SageX3OutlookInfrastructure.Caching;
using SageX3OutlookInfrastructure.ERP_Authentication;

using SageX3OutlookInfrastructure.Persistence.Repositories;
using SageX3OutlookInfrastructure.SageX3;


namespace SageX3OutlookInfrastructure.DependencyInjection;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // ERP services
        services.AddSingleton<ISageAuthService, SageAuthService>();
        services.AddSingleton<ISageX3Client, SageX3Client>();
        services.AddSingleton<ITokenCacheService, DistributedTokenCacheService>();

        // Repositories
        services.AddScoped<AuditRepository>();
        services.AddScoped<KnowledgeRepository>();
        services.AddScoped<LeadRepository>();
        services.AddScoped<OpportunityRepository>();

        // Logging
        services.AddSingleton<AuditService>();

        return services;
    }
}