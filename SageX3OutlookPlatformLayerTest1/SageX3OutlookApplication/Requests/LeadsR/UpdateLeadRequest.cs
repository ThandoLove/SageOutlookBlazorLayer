using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Requests.LeadsR;

public class UpdateLeadRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Company { get; set; }
    public string? CompanyName { get; set; }
    public string? Status { get; internal set; }
}