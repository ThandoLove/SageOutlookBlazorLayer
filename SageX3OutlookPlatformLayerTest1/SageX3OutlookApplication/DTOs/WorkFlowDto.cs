using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.DTOs;

public class WorkflowDto
{
    public Guid Id { get; set; }

    public string ActionType { get; set; } = string.Empty;

    public string EntityType { get; set; } = string.Empty;

    public Guid EntityId { get; set; }

    public string TriggeredBy { get; set; } = string.Empty;

    public DateTime ExecutedAt { get; set; }

    public string Status { get; set; } = string.Empty;
}