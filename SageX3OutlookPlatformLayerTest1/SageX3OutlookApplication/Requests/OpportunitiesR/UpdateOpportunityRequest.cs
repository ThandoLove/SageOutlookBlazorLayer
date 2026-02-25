using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Requests.OpportunitiesR;

public class UpdateOpportunityRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Value { get; set; }
    public string? Account { get; internal set; }
    public string? Stage { get; internal set; }
}