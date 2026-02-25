using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Enums;
using Microsoft.Extensions.Logging;

namespace SageX3OutlookApplication.Services;

public class AutoLinkService : IAutoLinkService
{
    private readonly IAutoLinkRepository _repository;
    private readonly IAuditService _auditService;
    private readonly ILogger<AutoLinkService> _logger;

    public AutoLinkService(
        IAutoLinkRepository repository,
        IAuditService auditService,
        ILogger<AutoLinkService> logger)
    {
        _repository = repository;
        _auditService = auditService;
        _logger = logger;
    }

    public async Task<AutoLinkResultDto> AutoLinkEmailAsync(string emailId)
    {
        _logger.LogInformation("Attempting to auto-link email: {EmailId}", emailId);

        var entity = await _repository.GetByEmailIdAsync(emailId);

        // Log the activity using your merged AuditService
        await _auditService.LogAsync(
            Guid.Empty, // Replace with actual User ID if available
            ActivityType.Integration,
            "EmailAutoLink",
            description: $"Processed auto-link for email: {emailId}");

        if (entity == null) return new AutoLinkResultDto { Success = false };

        return new AutoLinkResultDto
        {
            Id = entity.Id,
            Success = true,
            EmailId = entity.EmailId
        };
    }

    public async Task<List<AutoLinkResultDto>> GetAllAutoLinksAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(e => new AutoLinkResultDto
        {
            Id = e.Id,
            EmailId = e.EmailId
        }).ToList();
    }
}
