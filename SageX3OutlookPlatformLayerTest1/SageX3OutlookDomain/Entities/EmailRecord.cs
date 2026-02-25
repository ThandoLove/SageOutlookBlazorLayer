using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookDomain.Entities;
public class EmailRecord
{
    public Guid Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public List<string> To { get; set; } = new List<string>();
    public DateTime ReceivedAt { get; set; } = DateTime.UtcNow;
}