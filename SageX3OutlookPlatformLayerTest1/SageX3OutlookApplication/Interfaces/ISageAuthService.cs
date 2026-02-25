using SageX3OutlookApplication.Responses;

namespace SageX3OutlookApplication.Interfaces;
public interface ISageAuthService
{
    Task<TokenResponse> GetTokenAsync();
}