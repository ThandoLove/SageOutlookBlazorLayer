using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.DTOs;


public class EmailDto
{
    public Guid Id { get; set; }

    public string Subject { get; set; } = string.Empty;

    public string BodyPreview { get; set; } = string.Empty;

    public string From { get; set; } = string.Empty;

    public string To { get; set; } = string.Empty;

    public DateTime ReceivedAt { get; set; }

    public bool IsLinkedToContact { get; set; }

    public Guid? LinkedContactId { get; set; }

    internal object ToEntity()
    {
        throw new NotImplementedException();
    }
}