using SageX3OutlookDomain.Enums;
using SageX3OutlookDomain.ValueObjects;

namespace SageX3OutlookDomain.Entities;


public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.Employee;
    public PermissionSet Permissions { get; set; } = new PermissionSet();

    public bool CanDelete => Role == UserRole.Admin;

   
}