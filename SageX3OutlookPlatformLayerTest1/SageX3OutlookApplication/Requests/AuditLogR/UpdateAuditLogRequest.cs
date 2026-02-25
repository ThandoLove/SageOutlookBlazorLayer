using System.ComponentModel.DataAnnotations;

namespace SageX3OutlookApplication.Requests.AuditLogR;

public class UpdateAuditLogRequest
{
    [Required]
    public Guid AuditLogId { get; set; }

    [MaxLength(1000)]
    public string? Changes { get; set; }

    public DateTime? UpdatedTimestampUtc { get; set; }
}