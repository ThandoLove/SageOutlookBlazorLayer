using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.DTOs;

public class AuditLogDto
{
    public Guid Id { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string PerformedBy { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime Timestamp { get; set; }


}