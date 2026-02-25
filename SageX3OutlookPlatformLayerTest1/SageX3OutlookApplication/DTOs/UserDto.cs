using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.DTOs;

public class UserDto
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}