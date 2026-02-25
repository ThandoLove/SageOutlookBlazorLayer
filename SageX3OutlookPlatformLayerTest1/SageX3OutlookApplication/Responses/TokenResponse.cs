using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Responses;
public class TokenResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
}