using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace SageX3OutlookApplication.Requests.UserR;

public class UploadUserRequest
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public IFormFile Avatar { get; set; } = default!;
}