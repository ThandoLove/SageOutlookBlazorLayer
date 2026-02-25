using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.DTOs;

public class KnowledgeDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = string.Empty;
}