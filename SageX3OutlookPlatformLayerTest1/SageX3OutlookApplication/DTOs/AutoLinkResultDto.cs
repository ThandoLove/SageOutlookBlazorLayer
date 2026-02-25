using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.DTOs;

public class AutoLinkResultDto
{
    public bool IsMatched { get; set; }

    public Guid? MatchedContactId { get; set; }

    public string MatchedContactName { get; set; } = string.Empty;

    public double ConfidenceScore { get; set; }

    public string MatchingStrategy { get; set; } = string.Empty;
    public string? EmailId { get; internal set; }
    public object? LinkedContactId { get; internal set; }
    public string? Status { get; internal set; }
    public bool Success { get; internal set; }
    public Guid Id { get; internal set; }
}