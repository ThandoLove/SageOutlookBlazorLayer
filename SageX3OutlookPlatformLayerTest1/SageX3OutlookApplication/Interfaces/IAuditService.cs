using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Requests.AuditLogR;
using SageX3OutlookDomain.Enums;

namespace SageX3OutlookApplication.Interfaces;

public interface IAuditService
{
    // For API/UI Requests
    Task<AuditLogDto> CreateAsync(CreateAuditLogRequest request, CancellationToken cancellationToken = default);
    Task<List<AuditLogDto>> GetAllAsync(CancellationToken cancellationToken = default);

    // For Internal System Logging (Merged from Infrastructure)
    Task LogAsync(
        Guid userId,
        ActivityType activityType,
        string entityName,
        Guid? entityId = null,
        string? description = null);
}
