using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookDomain.Entities;
public class Lead
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Status { get; set; } = "New";
}