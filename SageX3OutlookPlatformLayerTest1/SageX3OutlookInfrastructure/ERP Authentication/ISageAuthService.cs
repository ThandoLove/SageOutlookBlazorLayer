using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookInfrastructure.ERP_Authentication;
public interface ISageAuthService
{
    Task<TokenResponse> GetTokenAsync();
}