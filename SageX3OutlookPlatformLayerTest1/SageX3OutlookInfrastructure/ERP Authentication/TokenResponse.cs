using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookInfrastructure.ERP_Authentication;
public class TokenResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
}