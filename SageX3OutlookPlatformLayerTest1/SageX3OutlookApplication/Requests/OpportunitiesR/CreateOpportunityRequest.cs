using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Requests.OpportunitiesR;

public class CreateOpportunityRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Value { get; set; }

    public string? Account { get; internal set; }

    public string? Stage { get; internal set; }
    public Guid OwnerId { get; internal set; }
}

