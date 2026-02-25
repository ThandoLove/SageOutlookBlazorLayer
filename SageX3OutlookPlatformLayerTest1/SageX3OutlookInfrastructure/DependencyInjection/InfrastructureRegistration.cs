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
        // Auth
        services.AddScoped<ISageAuthService, SageAuthService>();
        services.AddSingleton<ITokenCacheService, DistributedTokenCacheService>();

        // ERP
        services.AddScoped<ISageX3Client, SageX3Client>();

        // Repositories
        services.AddScoped<ILeadRepository, LeadRepository>();
        services.AddScoped<IAuditLogRepository, AuditRepository>();
        services.AddScoped<IOpportunityRepository, OpportunityRepository>();
        services.AddScoped<IKnowledgeRepository, KnowledgeRepository>();

        return services;
    }
}