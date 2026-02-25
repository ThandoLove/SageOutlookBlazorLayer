using System;
using SageX3OutlookDomain.Enums;

namespace SageX3OutlookDomain.Entities;

public class ActivityLog
{
    public Guid Id { get; set; }
    public ActivityType Type { get; set; }
    public string Description { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? EntityName { get; set; }
    public ActivityType ActivityType { get; set; }
    public Guid? EntityId { get; set; }
    public DateTime Timestamp { get; set; }
}