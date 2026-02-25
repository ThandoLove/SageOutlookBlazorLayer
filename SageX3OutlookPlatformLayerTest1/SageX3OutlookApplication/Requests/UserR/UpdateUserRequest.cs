
using System.ComponentModel.DataAnnotations;


namespace SageX3OutlookApplication.Requests.UserR;


public class UpdateUserRequest
{
    [Required]
    public Guid UserId { get; set; }

    [MaxLength(100)]
    public string? FirstName { get; set; }

    [MaxLength(100)]
    public string? LastName { get; set; }

    [EmailAddress]
    [MaxLength(255)]
    public string? Email { get; set; }

    [MaxLength(50)]
    public required string Role { get; set; }

    public bool? IsActive { get; set; }
   
    public Guid Id { get; internal set; }
}