using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace SageX3OutlookApplication.Requests.AuditLogR;


public class UploadAuditLogtRequest
{
    [Required]
    public Guid AuditLogId { get; set; }

    [Required]
    public IFormFile File { get; set; } = default!;
}