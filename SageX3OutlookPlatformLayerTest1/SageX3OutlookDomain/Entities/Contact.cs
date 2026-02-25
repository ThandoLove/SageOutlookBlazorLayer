using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookDomain.Entities;
public class Contact
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Company { get; set; }
    public DateTime CreatedAt { get; set; }
}