using System.ComponentModel.DataAnnotations;

namespace SageX3OutlookApplication.Requests.UserR;

public class CreateUserRequest
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Role { get; set; } = "Employee"; // This is the string we will parse

    public bool IsActive { get; set; } = true;
    public string? Name { get; internal set; }

    // REMOVED: Name and UserRole internal properties to avoid compiler confusion
}
