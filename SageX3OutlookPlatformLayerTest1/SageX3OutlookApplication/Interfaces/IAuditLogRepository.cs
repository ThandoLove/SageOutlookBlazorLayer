

using SageX3OutlookDomain.Entities;

namespace SageX3OutlookApplication.Interfaces;

public interface IAuditLogRepository
{
    // Use ActivityLog (the Entity name from your Domain)
    Task AddAsync(ActivityLog entity, CancellationToken cancellationToken = default);
    Task<List<ActivityLog>> GetAllAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
