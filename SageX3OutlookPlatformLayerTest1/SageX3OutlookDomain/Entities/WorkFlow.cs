using System;
using System.Collections.Generic;
using System.Text;


namespace SageX3OutlookDomain.Entities;

public class WorkFlow
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ActionType { get; set; } = string.Empty;
    public string EntityType { get; set; } = string.Empty;
    public Guid EntityId { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime ExecutedAt { get; set; } = DateTime.UtcNow;
}
