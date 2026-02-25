using Microsoft.EntityFrameworkCore;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;
using SageX3OutlookInfrastructure.Persistence;

namespace SageX3OutlookInfrastructure.Persistence.Repositories;

public class AuditRepository : IAuditLogRepository
{
    private readonly IntegrationDbContext _context;

    public AuditRepository(IntegrationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ActivityLog entity, CancellationToken cancellationToken = default)
    {
        // This will no longer show a red line under AddAsync
        await _context.AuditLogs.AddAsync(entity, cancellationToken);
    }

    public async Task<List<ActivityLog>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        // This fixes the Type Inference error
        return await _context.AuditLogs.ToListAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
