using SageX3OutlookDomain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SageX3OutlookApplication.Requests.AuditLogR;

public class CreateAuditLogRequest
{
    [Required]
    [MaxLength(100)]
    public string EntityName { get; set; } = string.Empty;

    [Required]
    public Guid EntityId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Action { get; set; } = string.Empty; // Created, Updated, Deleted

    [MaxLength(1000)]
    public string? Changes { get; set; }

    [Required]
    public Guid PerformedByUserId { get; set; }

    public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;
    public Guid UserId { get; internal set; }
    public ActivityType ActivityType { get; internal set; }
    public string? Description { get; internal set; }
}