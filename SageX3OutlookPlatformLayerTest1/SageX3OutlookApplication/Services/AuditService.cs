using Microsoft.Extensions.Logging;
using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.AuditLogR;
using SageX3OutlookDomain.Entities;
using SageX3OutlookDomain.Enums;


namespace SageX3OutlookApplication.Services;

public class AuditService : IAuditService
{
    private readonly IAuditLogRepository _repository;
    private readonly ILogger<AuditService> _logger;

    public AuditService(IAuditLogRepository repository, ILogger<AuditService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    // Standard Application Logic (DTOs)
    public async Task<AuditLogDto> CreateAsync(CreateAuditLogRequest request, CancellationToken cancellationToken)
    {
        var entity = new ActivityLog
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            ActivityType = request.ActivityType,
            EntityName = request.EntityName,
            EntityId = request.EntityId,
            Description = request.Description ?? string.Empty,
            Timestamp = DateTime.UtcNow
        };

        await _repository.AddAsync(entity, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        // Map to DTO (Ensure you have an extension method or manual mapping)
        return new AuditLogDto
        {
            Id = entity.Id,
            Description = entity.Description,
            Timestamp = entity.Timestamp
        };
    }

    // Merged Logic from Infrastructure (System-level logging)
    public async Task LogAsync(
        Guid userId,
        ActivityType activityType,
        string entityName,
        Guid? entityId = null,
        string? description = null)
    {
        try
        {
            // 1. Log to the Console/File via ILogger
            _logger.LogInformation(
                "User {UserId} performed {ActivityType} on {EntityName} {EntityId}. Details: {Description}",
                userId, activityType, entityName, entityId, description);

            // 2. Persist directly to Database
            var auditRecord = new ActivityLog
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ActivityType = activityType,
                EntityName = entityName,
                EntityId = entityId,
                Description = description ?? string.Empty,
                Timestamp = DateTime.UtcNow
            };

            await _repository.AddAsync(auditRecord);
            await _repository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Critical failure in Audit Logging for user {UserId}", userId);
        }
    }

    public async Task<List<AuditLogDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(e => new AuditLogDto { Id = e.Id, Description = e.Description }).ToList();
    }
}

